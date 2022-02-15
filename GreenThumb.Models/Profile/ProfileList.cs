using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Profile
{
    public class ProfileList
    {
        public int ProfileId { get; set; }

        public byte UserPhoto { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
