using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;
using Workplaces.Repository;

namespace Workplaces.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _repository;

        public OrderService(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Orders> AllOrders() => _repository.AllOrders();

        public void Delete(Orders Order) => _repository.Delete(Order);

        public Orders GetById(int id) => _repository.GetById(id);

        public void Insert(Orders Order) => _repository.Insert(Order);

        public void Update(Orders Order) => _repository.Update(Order);
    }
}
