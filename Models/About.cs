using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class About
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "About In English")]
        public string aboutEng { get; set; }
        [Required]
        [Display(Name = "About In Arabic")]
        public string aboutAr { get; set; }
        [Required]
        [Display(Name = "About Display Image")]
        public string aboutImg { get; set; }
        [Required]
        [Display(Name = "About Image Path")]
        public string ImgPath { get; set; }

    }
}