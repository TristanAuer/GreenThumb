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

        [Key, ForeignKey("MessageBoard")]
        [Display(Name = "ReplyId")]
        public int ReplyId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Reply value cannot exceed 500 characters. ")]
        public string Reply { get; set; }
        [ForeignKey(nameof(MessageBoard))]
        public virtual ICollection<MessageBoard> MessageBoard { get; set; }
        [Required]
        public byte ReplyPhoto { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
