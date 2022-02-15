using System;
using System.Collections.Generic;
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
       
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
