using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workplaces.Models;

namespace Workplaces.Repository
{
    public interface IOrdersRepository
    {
        IEnumerable<Orders> AllOrders();
        Orders GetById(int id);
        void Insert(Orders Order);
        void Update(Orders Order);
        void Delete(Orders Order);
    }
}
