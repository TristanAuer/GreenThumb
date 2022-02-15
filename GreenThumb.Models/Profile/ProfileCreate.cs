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
        public DateTimeOffset CreatedUtc { get; set; }
        public string ThreadTitle { get; set; }
        public byte ThreadPhoto { get; set; }
        public React Content { get; set; }
        public byte UserPhoto { get; set; }
    }
}
