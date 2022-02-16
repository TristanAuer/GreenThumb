using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Profile
{
    public class ProfileCreate
    {
        [Required]
        public int ProfileId { get; set; }

        [Required]
        [Display(Name ="0-4 Reaction")]
        public React Content { get; set; }
        public byte UserPhoto { get; set; }

    }
}
