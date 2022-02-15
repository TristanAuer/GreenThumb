using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum Plants { Beets, Carrots, Lettuce, Radish, Artichoke, Arugula, AsianGreens, Asparagus, Beans, Broccoli }
    public class GardenTable
    {
        [Key]
        [Display(Name = "GardenId")]
        public int GardenId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        public string GardenName { get; set; }
        [Required]
        public Plants PlantType { get; set; }
        [Required]
        public int PlantCount { get; set; }
        [ForeignKey(nameof(Profile))]
        public virtual ICollection<Profile> Profile{ get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
