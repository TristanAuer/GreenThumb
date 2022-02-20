using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class GardenList
    {
        public int GardenId { get; set; }
        public string GardenName { get; set; }
        public Plants PlantType { get; set; }
        public int PlantCount { get; set; }
        public byte[] PlantPhoto { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}

