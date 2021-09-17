using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplaces.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceId { get; set; }
        public Workplace Workplace { get; set; }

    }
}
