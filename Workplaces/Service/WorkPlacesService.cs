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

        public void Delete(Workplace workplace) => _repository.Delete(workplace);

        public Workplace GetById(int id) => _repository.GetById(id);

        public void Insert(Workplace workplace) => _repository.Insert(workplace);

        public void Update(Workplace workplace) => _repository.Update(workplace);
    }
}
