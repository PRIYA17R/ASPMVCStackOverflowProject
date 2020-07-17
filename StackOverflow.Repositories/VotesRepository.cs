using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModel;

namespace StackOverflow.Repositories
{

    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
    public class VotesRepository : IVotesRepository
    {
        StackeOverflowDBContext db;

        public VotesRepository()
        {
            db = new StackeOverflowDBContext();

        }

        public void UpdateVote(int aid, int uid, int value)
        {
            int updateValue =0 ;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;
            Vote vote = db.Votes.Where(t => t.AnswerID == aid && t.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote()
                {
                    AnswerID = aid,
                    UserID = uid,
                    VoteValue = value
                };
                db.Votes.Add(newVote);
            }

            db.SaveChanges();

        }
    }
}
