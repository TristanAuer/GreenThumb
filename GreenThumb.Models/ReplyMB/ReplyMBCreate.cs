using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.ReplyMB
{
    public class ReplyMBCreate
    {
        public int ReplyId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Reply value cannot exceed 500 characters. ")]
        public string Reply { get; set; }

        public byte ReplyPhoto { get; set; }
    }
}
