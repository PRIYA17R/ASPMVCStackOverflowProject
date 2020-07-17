using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackOverflow.ViewModels
{
   public class CategoriesViewModel
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
