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
        [Display (Name = "ProfileId")]
        public int ProfileId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public byte UserPhoto { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

        [ForeignKey(nameof(MessageBoard))]
        public virtual ICollection<MessageBoard> MessageBoard { get; set; }

        [ForeignKey(nameof(GardenTable))]
        public virtual ICollection<GardenTable> GardenTable { get; set; }
    }
}
