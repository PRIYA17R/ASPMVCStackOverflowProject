using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackOverflow.ViewModels
{
   public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email can't be blank")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string  Password { get; set; }

        [Required(ErrorMessage ="Confirm password")]
        [Display(Description ="Confirm Password")]
        [Compare("Password", ErrorMessage =("Password and Confirm Password much match"))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Name can not be blank")]
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "Invalid  Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile can not be blank")]
        public string Mobile { get; set; }


    }
}
