using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Models;

namespace Bamboo.ViewModels
{
    public class LoginUserViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public LoginUserViewModel() { }
    }
}
