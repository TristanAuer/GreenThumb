﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Profile
{
    public class ProfileEdit
    {

        public int ProfileId { get; set; }

        [Display(Name = "User Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
        public string GardenName { get; set; }
        public Byte[] UserPhoto { get; set; }
        public ImageModel Image { get; set; }
        public int ImageID { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
