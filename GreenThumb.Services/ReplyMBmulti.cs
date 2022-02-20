
using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class ReplyMBmulti
    {
        public IEnumerable<ReplyMBList> RecentReply { get; set; }
        public IEnumerable<MessageBoardDetail> GetCurrentMessage { get; set; }
       

    }
}
