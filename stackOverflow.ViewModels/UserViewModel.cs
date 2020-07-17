using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackOverflow.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public bool IsAdmin { get; set; }
    }
}
