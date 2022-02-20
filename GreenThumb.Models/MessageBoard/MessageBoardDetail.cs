using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class MessageBoardDetail
    {
        public int ThreadId { get; set; }
        [Display(Name = "Title")]
        public string ThreadTitle { get; set; }
        [Display(Name = "Photos")]
        public byte[] ThreadPhoto { get; set; }
        //[Display(Name = "React")]
        //public React Content { get; set; }
        [Display(Name = "Content")]
        public string ThreadContent { get; set; }
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
