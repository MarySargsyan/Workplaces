using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;
using Workplaces.Repository;

namespace Workplaces.Service
{
    public class WorkPlacesService : IWorkPlacesService
    {
        private readonly IWorkPlacesRepository _repository;

        public WorkPlacesService(IWorkPlacesRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Workplace> AllPlaces() => _repository.AllPlaces();

    }
}
