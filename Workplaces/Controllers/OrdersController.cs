using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;
using Workplaces.Service;
using System.Security.Claims;


namespace Workplaces.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWorkPlacesService _workPlaces;

        public OrdersController(AppDbContext context, IWorkPlacesService workPlaces)
        {
            _context = context;
            _workPlaces = workPlaces;
        }

        public IActionResult Index(DateTime date)
        {  
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Items = _context.Items.ToList();
            ViewBag.Date = date;

            List<Workplace> workplaces = _workPlaces.AllPlaces().ToList();
            List<Workplace> workplaces1 = new List<Workplace>();

            if (date != null)
            {
                foreach (Workplace w in workplaces)
                {
                    foreach (Orders orders in w.Orders)
                    {
                        if (orders.Date != date)
                        {
                            workplaces1.Add(w);
                        }
                    }
                }
                //var results = workplaces.GroupBy(x => x.Id).Select(x => x.First()).ToList();
                return View(workplaces1);

            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(int? id, DateTime date)
        {
            if (ModelState.IsValid)
            {
                Orders order = new Orders()
                {
                    UserId = GetCorrentUserId(),
                    Date = date,
                    WorkPlaceId = id
                    };
                _context.Orders.Add(order);
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
