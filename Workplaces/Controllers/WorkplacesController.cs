 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workplaces.Models;
using Workplaces.Service;

namespace Workplaces.Controllers
{
    public class WorkplacesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWorkPlacesService _workPlaces;
        private AppDbContext context;

        public WorkplacesController(AppDbContext context, IWorkPlacesService workPlaces)
        {
            _context = context;
            _workPlaces = workPlaces;
        }


        // GET: Workplaces
        public ActionResult Index()
        {
            ViewBag.Items = _context.Items.ToList();
            ViewBag.PItems = _context.PlaceItems.ToList();
            return View(_workPlaces.AllPlaces().ToList());
        }

        // поменять это на orders
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Users = _context.Users.ToList();
            var workplace = _workPlaces.GetById(Convert.ToInt32(id));
            return View(workplace);
        }

        // GET: Workplaces/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlaceNumber")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                _workPlaces.Insert(workplace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workplace);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Items = _context.Items.ToList();
            ViewBag.SelectedItems = _context.Items.Where(i => i.placeItem.Where(p => p.WorkplaceId == id).Count() > 0 ? true : false).ToList();
            var workplace = _workPlaces.GetById(Convert.ToInt32(id));
            return View(workplace);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlaceNumber")] Workplace workplace, int[] selectedItems)
        {
            foreach(PlaceItem placei in _context.PlaceItems.Where(p=>p.WorkplaceId == id))
            {
                _context.PlaceItems.Remove(placei);
            }
            foreach (var i in _context.Items.Where(co => selectedItems.Contains(co.Id)))
            {
               PlaceItem placeItem = new PlaceItem()
               {
                 ItemId = i.Id,
                 WorkplaceId = id
               };
               _context.PlaceItems.Add(placeItem);
            }
            _context.Update(workplace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Workplaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var workplace = _workPlaces.GetById(Convert.ToInt32(id));
            return View(workplace);
        }

        // POST: Workplaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workplace = _workPlaces.GetById(Convert.ToInt32(id));
            _workPlaces.Delete(workplace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkplaceExists(int id)
        {
            return _context.Workplaces.Any(e => e.Id == id);
        }
    }
}
