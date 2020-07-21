using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModel;

namespace StackOverflow.Repositories
{

    public interface IQuestionsRepository
    {
        void UpdateQuestions(Question Q);
        void InsertQuestion(Question Q);

        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswerCount(int qid, int value);

        void UpdateQuestionViewsCount(int qid, int value);
        void DeleteQuestion(int qid);

        List<Question> GetQuestions();

        List<Question> GetQuestionsByQuestionID(int qid);
    }
    public class QuestionsRepository : IQuestionsRepository
    {
        StackeOverflowDBContext db;

        public QuestionsRepository()
        {
            db = new StackeOverflowDBContext();
        }
        public void DeleteQuestion(int qid)
        {
            Question Q = db.Questions.Where(t => t.QuestionID == qid).FirstOrDefault();
            if(Q != null)
            {
                db.Questions.Remove(Q);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> Q = db.Questions.OrderByDescending(t=> t.QuestionDateAndTime).ToList();
            return Q  ;

        }

        public List<Question> GetQuestionsByQuestionID(int qid)
        {
            List<Question> Q = db.Questions.Where(t => t.QuestionID == qid).ToList();
            return Q;
        }

       

        public void InsertQuestion(Question Q)
        {
            db.Questions.Add(Q);
            db.SaveChanges();
        }

        public void UpdateQuestionAnswerCount(int qid, int value)
        {
            Question existingQ = db.Questions.Where(t => t.QuestionID == qid).FirstOrDefault();
            if (existingQ != null)
            {
                existingQ.AnswerCount += value;
                db.SaveChanges();
            }
        }


            public void UpdateQuestions(Question Q)
        {
            Question existingQ = db.Questions.Where(t => t.QuestionID == Q.QuestionID).FirstOrDefault();
            if(existingQ != null)
            {
                existingQ.QuestionName = Q.QuestionName;
                existingQ.QuestionDateAndTime = Q.QuestionDateAndTime;
                existingQ.CategoryID = Q.CategoryID;
                db.SaveChanges();
            }

        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            Question existingQ = db.Questions.Where(t => t.QuestionID == qid).FirstOrDefault();
            if (existingQ != null)
            {
                existingQ.ViewsCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            Question existingQ = db.Questions.Where(t => t.QuestionID == qid).FirstOrDefault();
            if (existingQ != null)
            {
                existingQ.VotesCount += value;
                db.SaveChanges();
            }
        }
    }
}
