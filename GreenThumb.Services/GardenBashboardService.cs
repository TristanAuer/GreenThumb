using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class GardenBashboardService
    {
        public IEnumerable<GardenTable> MostRecentPlants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GardenTable.OrderByDescending(t => t.CreatedUtc);
                return query.ToArray();
                
            }
        }
    }
}
