using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class ForgetPassword
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Username" )]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        [DataType("password")]

        public string newPassword { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType("password")]
        [Compare("newPassword")]
        public string conFirmNewPass { get; set; }
        public string code { get; set; }
    }
}