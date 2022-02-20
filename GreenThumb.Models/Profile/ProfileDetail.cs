using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Profile
{
    public class ProfileDetail
    {
        public int ProfileId { get; set; }
        public string GardenName { get; set; }
        public string UserName { get; set; }
        public byte[] UserPhoto { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
