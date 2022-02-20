using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class ReplyMBList
    {
        [Display(Name = "ReplyId")]
        public int ReplyId { get; set; }
        [Display(Name = "Reply")]
        public string Reply { get; set; }
        [Display(Name = "Thread")]
        public int ThreadId { get; set; }
        [Display(Name = "Photo")]
        public byte[] ReplyPhoto { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
