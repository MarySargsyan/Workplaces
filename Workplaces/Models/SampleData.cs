using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workplaces.Models
{
    public class SampleData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Workplaces.Any())
            {
                context.Workplaces.AddRange(
                    new Workplace
                    {
                        PlaceNumber = 1
                    },
                    new Workplace
                    {
                        PlaceNumber = 2
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
