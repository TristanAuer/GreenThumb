using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Garden
{
    public class GardenList
    {
        public int GardenId { get; set; }
        public string GardenName { get; set; }
        public Plants PlantType { get; set; }
        public int PlantCount { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
