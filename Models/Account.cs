using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocStudiosMVCProject.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [Required (ErrorMessage = "cvv")]
        [Display(Name = "First Name")]
        public string  firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType("password")]
        
        public string password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType("password")]
        [Compare("password")]
        public string conFirmPass { get; set; }
        public string code { get; set; }

        public readonly string ErrorMessage = "Username or Password is Invalid";


    }
}