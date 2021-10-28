using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocStudiosMVCProject.Models
{
    public class Portfolio
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string PortImgName { get; set; }
        [Required]
        public string PortImgPath { get; set; }

    }
}