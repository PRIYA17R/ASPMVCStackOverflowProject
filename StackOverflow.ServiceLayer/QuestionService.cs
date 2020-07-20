using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using stackOverflow.ViewModels;
using StackOverflow.DomainModel;
using StackOverflow.Repositories;
using AutoMapper.Configuration;

namespace StackOverflow.ServiceLayer
{
    public interface IQuestionService
    {

        void InsertQuestion(NewQuestionViewModel nqvm);
        void UpdateQuestionDetails(EditQuestionViewModel qvm);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);

        void DeleteQuestion(int qid);
        List<QuestionViewModel> GetQuestions();

        QuestionViewModel GetQuestionsByQuestionID(int qid, int UserID);

    }
   public class QuestionService : IQuestionService
    {
        IQuestionsRepository qr;
        public QuestionService()
        {
            qr = new QuestionsRepository();
        }

        public void DeleteQuestion(int qid)
        {
            qr.DeleteQuestion(qid);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetQuestions();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap< Question, QuestionViewModel>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);
            return qvm;
        }

        public QuestionViewModel GetQuestionsByQuestionID(int qid, int userID =0)
        {
            Question q = qr.GetQuestionsByQuestionID(qid).FirstOrDefault();
            QuestionViewModel qvm = null;
            if(q != null) { 
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>(); cfg.IgnoreUnMapped(); });
                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<Question, QuestionViewModel>(q);
                foreach (var item in qvm.Answers)
                {
                    item.CurrentUserVoteType = 0;
                    VoteViewModel vote = item.Votes.Where(t => t.UserID == userID).FirstOrDefault();
                    if(vote != null)
                    {
                        item.CurrentUserVoteType = vote.VoteValue;
                    }
                }
            }
            return qvm;

        }

        public void  InsertQuestion(NewQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewAnswerViewModel, Question>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<NewQuestionViewModel, Question>(qvm);

            qr.InsertQuestion(q);
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            qr.UpdateQuestionAnswerCount(qid, value);
        }

       public  void UpdateQuestionDetails(EditQuestionViewModel qvm)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditQuestionViewModel, Question>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<EditQuestionViewModel, Question>(qvm);
            qr.UpdateQuestions(q);
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            qr.UpdateQuestionViewsCount(qid, value);
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            qr.UpdateQuestionVotesCount(qid, value);
        }
    }
}
