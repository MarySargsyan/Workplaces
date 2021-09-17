using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workplaces.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int? WorkPlaceId { get; set; }
        public Workplace Workplace { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
