using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;

namespace Workplaces.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Orders> AllOrders()
        {
            using (_context)
            {
                var Orders = _context.Orders.ToList();
                return Orders;
            }
        }

        public void Delete(Orders Order)
        {
            _context.Orders.Remove(Order);
        }

        public Orders GetById(int id)
        {
           return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Orders Order)
        {
            _context.Orders.Add(Order);
        }

        public void Update(Orders Order)
        {
            _context.Orders.Update(Order);
        }
    }
}
