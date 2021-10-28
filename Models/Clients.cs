using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "Client Display Image")]
        public string ClientImg { get; set; }
        [Required]
        [Display(Name = "Client Image Path")]
        public string ClientImgPath { get; set; }
    }
}