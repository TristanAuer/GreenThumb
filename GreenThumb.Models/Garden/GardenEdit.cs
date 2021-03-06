using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class GardenEdit
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        public string GardenName { get; set; }
        [Required]
        public int GardenId { get; set; }

        public Plants PlantType { get; set; }

        public byte[] PlantPhoto { get; set; }
        public int PlantCount { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
