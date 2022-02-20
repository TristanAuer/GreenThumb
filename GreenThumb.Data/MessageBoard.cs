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
        Positive = 0,
        Negative = 1,
        Professional = 2,
        Ammateur = 3,
        Funny = 4
    }
    public class MessageBoard
    {

        [Key]
        public int ThreadId { get; set; }
        [Required]
        public Guid OwnerGUID { get; set; }
        [Required]
        public string ThreadContent { get; set; }
        [Required]
        public string ThreadTitle { get; set; }
        
        public byte[] ThreadPhoto { get; set; }
        [Required]
        [Display(Name = "Useful")]
        [Range(0, 4)]
        public React ReactionType { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<ReplyMB> Reply { get; set; }

        [ForeignKey(nameof(Profile))]
        public int? UserId { get; set; }
        public virtual Profile Profile { get; set; }
        
    }
}
