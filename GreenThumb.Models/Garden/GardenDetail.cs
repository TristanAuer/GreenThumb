using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Garden
{
    public class GardenDetail
    { 
        public string GardenName { get; set; }
        public int GardenId { get; set; }
        
        public Plants PlantType { get; set; }
        public int PlantCount { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
