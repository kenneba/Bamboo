using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bamboo.ViewModels
{
    public class AddArtistViewModel
    {
        public int ID { get; set; }
        
        
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        
        [Required(ErrorMessage = "Please Enter first name")]
        [Display (Name="First Name")]
        public string FirstName { get; set; }
        
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        
        
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
