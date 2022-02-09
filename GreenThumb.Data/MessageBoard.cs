using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class MessageBoard
    {
        [Key]
        [Display(Name = "ThreadId")]
        public int ThreadId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Post value cannot exceed 500 characters. ")]
        public string ThreadContent { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "Title value cannot exceed 25 characters.")]
        public string ThreadTitle { get; set; }
        [Required]
        public byte ThreadPhoto { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
