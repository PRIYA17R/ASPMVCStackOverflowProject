﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stackOverflow.ViewModels
{
   public class AnswersViewModel
    {

        public int AnswerID { get; set; }

        public DateTime AnswerDateAndTime { get; set; }

        public int UserID { get; set; }

        public int QuestionID { get; set; }

        public int VotesCount { get; set; }

        public virtual  UserViewModel User { get; set; }

        public virtual List<VoteViewModel> Votes { get; set; }

        public int CurrentUserVoteType { get; set; }
    }
}
