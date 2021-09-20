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
            //List<Workplace> workplaces1 = new List<Workplace>();
            //if (date != null)
            //{
            //    foreach(Workplace w in workplaces)
            //    {
            //        foreach(Orders orders in w.Orders)
            //        {
            //            if(orders.Date != date)
            //            {
            //                workplaces1.Add(w);
            //            }
            //        }
            //    }
            //    return View(workplaces1);

            //}
            ViewBag.Items = _context.Items.ToList();
            return View(_workPlaces.AllPlaces().ToList());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(int? id, DateTime date)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user userId

            if (ModelState.IsValid)
            {
                Orders order = new Orders()
                {
                    UserId = 2,
                    Date = date,
                    WorkPlaceId = id
                    };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

    }
}
