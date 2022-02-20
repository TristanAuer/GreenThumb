using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class ReplyMBEdit
    {
        [Required]
        public Guid OwnerGUID { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Reply value cannot exceed 500 characters. ")]
        public string Reply { get; set; }
        [Required]
        public byte[] ReplyPhoto { get; set; }
        [Required]
        public DateTimeOffset ModifiedUtc { get; set; }
        [Required]
        public int ThreadId { get; set; }
        [Required]
        public int ProfileId { get; set; }
    }
}
