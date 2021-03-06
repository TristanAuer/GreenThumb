using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class ProfileList
    {
        public int ProfileId { get; set; }
        public string GardenName { get; set; }

        public byte[] UserPhoto { get; set; }

        public string UserName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
