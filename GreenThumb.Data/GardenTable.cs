using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum Plants { Beets = 0, Carrots = 1, Lettuce = 2, Radish = 3, Artichoke = 4, Arugula = 5, AsianGreens = 6, Asparagus = 7, Beans = 8, Broccoli = 9}
    public class GardenTable
    {
        [Key]
        [Display(Name = "GardenId")]
        public int GardenId { get; set; }
        [Required]
        public Guid OwnerGUID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        public string GardenName { get; set; }
        [Display(Name ="Plants")]
        public Plants PlantType { get; set; }
        
        public byte[] PlantPhoto { get; set; }
        public int PlantCount { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset CreatedUtc { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset ModifiedUtc { get; set; }

        [ForeignKey(nameof(Profile))]
        public int? UserId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
