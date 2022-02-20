﻿using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models
{
    public class MessageBoardCreate
    {
        [Required]
        [MaxLength(8000, ErrorMessage = "Max character count 8000.")]
        [Display(Name = "Content")]
        public string ThreadContent { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many character in this field.")]
        [Display(Name = "Title")]
        public string ThreadTitle { get; set; }
        [Display(Name = "Photo")]
        public byte[] ThreadPhoto { get; set; }
        public React Content { get; set; }
    }
}
