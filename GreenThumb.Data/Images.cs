using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        public Guid OwnerGUID { get; set; }

        [Required]
        public byte[] ImageData { get; set; }
    }
}

