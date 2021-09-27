using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;

namespace Workplaces.Repository
{
    public class WorkplacesRepository : IWorkPlacesRepository
    {
        private AppDbContext _context;

        public WorkplacesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Workplace> AllPlaces()
        {
            using (_context)
            {
                var WorkPlaces = _context.Workplaces.ToList();
                return WorkPlaces;
            }
        }

        public void Delete(Workplace workplace)
        {
            _context.Workplaces.Remove(workplace);
        }

        public Workplace GetById(int id)
        {
            return _context.Workplaces.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Workplace workplace)
        {
            _context.Workplaces.Add(workplace);
        }

        public void Update(Workplace workplace)
        {
            _context.Workplaces.Update(workplace);
        }
    }
}
