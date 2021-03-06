﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace stackOverflow.ViewModels
{
    public class QuestionViewModel
    {

        public int QuestionID { get; set; }
        public string QuestionName { get; set; }

        public DateTime QuestionDateAndTime { get; set; }

        public int? UserID { get; set; }

        public int? CategoryID { get; set; }

        public int VotesCount { get; set; }


        public int AnswerCount { get; set; }


        public int ViewsCount { get; set; }

        public UserViewModel User { get; set; }

        public CategoriesViewModel Category { get; set; }

        public virtual List<AnswersViewModel> Answers { get; set; }




    }

}
