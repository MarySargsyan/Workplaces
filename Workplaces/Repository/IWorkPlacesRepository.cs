using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;

namespace Workplaces.Repository
{
    public interface IWorkPlacesRepository
    {
        IEnumerable<Workplace> AllPlaces();
        Workplace GetById(int id);
        void Insert(Workplace workplace);
        void Update(Workplace workplace);
        void Delete(Workplace workplace);

    }
}
