using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplaces.Models
{
    public class PlaceItem
    {
        public int WorkplaceId { get; set; }
        public int ItemId { get; set; }
        public Workplace workplace { get; set; }
        public Items items { get; set; }
    }
}
