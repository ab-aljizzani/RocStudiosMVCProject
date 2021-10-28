using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class Services
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Service English Title")]
        public string ServTitleEng { get; set; }
        [Required]
        [Display(Name = "Service Arabic Title")]
        public string ServTitleAr { get; set; }
        [Required]
        [Display(Name = "Service English Description")]
        public string ServDescEng { get; set; }
        [Required]
        [Display(Name = "Service Arabic Description")]
        public string ServDescAr { get; set; }
        [Required]
        [Display(Name = "Service Display Image")]
        public string ServImg { get; set; }
        [Required]
        [Display(Name = "Service Image Path")]
        public string ServImgPath { get; set; }
        
    }
}