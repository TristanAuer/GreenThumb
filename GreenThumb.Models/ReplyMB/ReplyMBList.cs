using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.ReplyMB
{
    public class ReplyMBList
    {
        public int ReplyId { get; set; }
        
        public string Reply { get; set; }

     
        public byte ReplyPhoto { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
