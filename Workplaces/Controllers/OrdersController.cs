using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;
using Workplaces.Service;
using System.Security.Claims;
using System.Data.Entity;

namespace Workplaces.Controllers
{
    public class OrdersController : Controller
    {
        public static DateTime Orderdate = new DateTime();
        private readonly AppDbContext _context;
        private readonly IWorkPlacesService _workPlaces;
        private readonly IOrderService _orders;

        public OrdersController(AppDbContext context, IWorkPlacesService workPlaces, IOrderService orders)
        {
            _orders = orders;
            _context = context;
            _workPlaces = workPlaces;
        }

        public IActionResult Index(DateTime date)
        {  
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Items = _context.Items.ToList();
            ViewBag.CorrentUserOrders = _context.Orders.ToList().Where(order => order.UserId == GetCorrentUserId()).ToList();
            ViewBag.PItems = _context.PlaceItems.ToList();

            Orderdate = date;
            List<Workplace> workplaces = _context.Workplaces.ToList();
            foreach(Orders orders in _context.Orders.ToList())
            {
                if(orders.Date == date)
                {
                    workplaces.Remove(orders.Workplace);
                }
            }
            return View(workplaces);

        }

        public IActionResult OrderTable(int? id)
        {
            ViewBag.d = Orderdate;
            var workplace = _workPlaces.GetById(Convert.ToInt32(id));
            return View(workplace);
        }

        [HttpPost, ActionName("OrderTable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Orders order = new Orders()
                {
                    UserId = GetCorrentUserId(),
                    Date = Orderdate,
                    WorkPlaceId = id
                };
               _orders.Insert(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");

        }
        public int GetCorrentUserId() 
        {
            int CorrentUserId = 0;
            foreach (User user in _context.Users.ToList())
            {
                if (User.Identity.Name == user.Email)
                {
                    CorrentUserId = user.Id;
                }
            }
            return (CorrentUserId);
        }

    }
}
