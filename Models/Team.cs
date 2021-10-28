using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class Team
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Team English Name")]
        public string TeamMemEngName { get; set; }
        [Required]
        [Display(Name = "Team Arabic Name")]
        public string TeamMemArName { get; set; }
        [Required]
        [Display(Name = "Team English Job Name")]
        public string TeamMemEngJob { get; set; }
        [Required]
        [Display(Name = "Team Arabic Job Name")]
        public string TeamMemArJob { get; set; }
        [Required]
        [Display(Name = "Team Display Image")]
        public string  TeamMemImge { get; set; }
        [Required]
        [Display(Name = "Team Image Path")]
        public string  TeamMemImgPath { get; set; } 

    }
}