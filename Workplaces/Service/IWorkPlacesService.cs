using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;

namespace Workplaces.Service
{
   public interface IWorkPlacesService
    {
        IEnumerable<Workplace> AllPlaces();

    }
}
