using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class ReplyMB
    {

        [Key]
        [Display(Name = "ReplyId")]
        public int ReplyId { get; set; }
        [Required]
        public Guid OwnerGUID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Reply value cannot exceed 500 characters. ")]
        public string Reply { get; set; }
        public byte[] ReplyPhoto { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        
        
        [ForeignKey(nameof(MessageBoard))]
        public int ThreadId { get; set; }
        public virtual MessageBoard MessageBoard { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
