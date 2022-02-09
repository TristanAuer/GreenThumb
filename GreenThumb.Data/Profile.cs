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
        public Guid UserId { get; set; }
        [ForeignKey(nameof(MessageBoard))]
        public int ThreadId { get; set; }
        
        [Required]
        [ForeignKey(nameof(ReplyMB))]
        public int ReplyID { get; set; }
        [ForeignKey(nameof(GardenTable))]
        public int GardenId { get; set; }

        public byte UserPhoto { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
