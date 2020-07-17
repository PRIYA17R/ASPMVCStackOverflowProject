using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace StackOverflow.DomainModel
{
    public class User
    {   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }


        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        public Boolean IsAdmin  { get; set; }


    }
}
