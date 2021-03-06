using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class GardenCreate
    {
        [Required]
        [Display(Name = "Plant Group")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        public string GardenName { get; set; }

        public Plants PlantType { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The quantity must be 0 or more.")]
        public int PlantCount { get; set; }
        public byte[] PlantPhoto { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
