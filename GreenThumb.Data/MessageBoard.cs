using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum React
    {
        Positive,
        Negative,
        Professional,
        Ammateur,
        Funny
    }
    public class MessageBoard
    {

        [Key]
        [Display(Name = "ThreadId")]
        public Guid ThreadId { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string ThreadContent { get; set; }
        [Required]
        public string ThreadTitle { get; set; }
        public byte ThreadPhoto { get; set; }
        [Required]
        [Display(Name = "Useful")]
        [Range(0, 4)]
        public React Content { get; set; }
        [ForeignKey(nameof(ReplyMB))]
        public virtual ICollection<ReplyMB> Reply { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
