using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplaces.Models
{
    public class Workplace
    {
        public int Id { get; set; }

        public int PlaceNumber { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Items> Items { get; set; }

        public Workplace()
        { 
            Orders = new List<Orders>();
            Items = new List<Items>();
        }

    }
}
