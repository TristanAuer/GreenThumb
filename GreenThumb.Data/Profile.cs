using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class Profile
    {
        
        [Key]
        public int ProfileId { get; set; }
        [Required]
        public Guid OwnerGUID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
        [Display(Name = "User Picture")]
        public byte[] UserPhoto { get; set; }
        [Required]
        [Display(Name = "Account Creation Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual ICollection<MessageBoard> MessageBoard { get; set; } = new List<MessageBoard>();
        public virtual ICollection<GardenTable> GardenTable { get; set; } = new List<GardenTable>();
        public virtual ICollection<ReplyMB> Reply { get; set; } = new List<ReplyMB>();



    }
}
