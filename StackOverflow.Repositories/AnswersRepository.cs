using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModel;

namespace StackOverflow.Repositories
{

    public interface IAnswersRepository
    {
        void UpdateAnswers(Answer A);
        void InsertAnswers(Answer A);

        void UpdateAnswerVotesCount(int aid, int uid,  int value);
        void DeleteAnswers(int aid);
        List<Answer> GetAnswersByAnswerID(int aid);

        List<Answer> GetAnswersByQuestionID(int aid);
    }
    public class AnswersRepository : IAnswersRepository
    {
        StackeOverflowDBContext db;
        IQuestionsRepository qr;
        IVotesRepository vr;

      public  AnswersRepository()
        {
            db = new StackeOverflowDBContext();
            qr = new QuestionsRepository();
            vr = new VotesRepository();
        }
        public void DeleteAnswers(int aid)
        {
            Answer ans = db.Answers.Where(t => t.AnswerID == aid).FirstOrDefault();
            if(ans != null)
            {
                db.Answers.Remove(ans);
                db.SaveChanges();
                qr.UpdateQuestionAnswerCount(ans.QuestionID, -1);
            }
        }

        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            List<Answer> ans = db.Answers.Where(t => t.AnswerID == aid).ToList();
            return ans;
        }

        public List<Answer> GetAnswersByQuestionID(int aid)
        {
            List<Answer> ans = db.Answers.Where(t => t.QuestionID == aid).ToList();
            return ans;
        }

        public void InsertAnswers(Answer a)
        {
            db.Answers.Add(a);
            db.SaveChanges();
            qr.UpdateQuestionAnswerCount(a.QuestionID, 1);
        }

        public void UpdateAnswers(Answer A)
        {
            Answer ans = db.Answers.Where(t => t.AnswerID == A.AnswerID).FirstOrDefault();
            if (ans != null)
            {
                ans.AnswerText = A.AnswerText;
                db.SaveChanges();
            }
        }

        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            Answer  existingA = db.Answers.Where(t => t.AnswerID == aid).FirstOrDefault();
            if (existingA != null)
            {
                existingA.VotesCount += value;
                db.SaveChanges();
                qr.UpdateQuestionVotesCount(existingA.QuestionID, value);
                vr.UpdateVote(aid, uid, value);
            }

        }
    }
}
