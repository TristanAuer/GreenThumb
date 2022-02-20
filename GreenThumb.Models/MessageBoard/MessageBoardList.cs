using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.MessageBoard
{
    public class MessageBoardList 
    {
        public int ThreadId { get; set; }
        [Display(Name = "Title")]
        public string ThreadTitle { get; set; }
        [Display(Name = "Photos")]
        public byte[] ThreadPhoto { get; set; }
        public React Content { get; set; }
        [Display(Name = "Content")]
        public string ThreadContent { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Updated")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
