using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackOverflow.ViewModels
{
    public class VoteViewModel
    {
        public int UserID { get; set; }
        public int VoteID { get; set; }
        public int AnswerID { get; set; }

        public int VoteValue { get; set; }
    }
}
