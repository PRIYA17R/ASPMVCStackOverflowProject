using System;
using System.Collections.Generic;
using System.Linq;
using stackOverflow.ViewModels;
using StackOverflow.DomainModel;
using StackOverflow.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
using StackOverflow.ServiceLayer;

namespace StackOverflowProject.ServiceLayer
{
    public interface IAnswersService
    {
        void InsertAnswer(NewAnswerViewModel avm);
        void UpdateAnswer(EditAnswerViewModel avm);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<AnswersViewModel> GetAnswersByQuestionID(int qid);
        AnswersViewModel GetAnswerByAnswerID(int AnswerID);
    }
    public class AnswersService : IAnswersService
    {
        IAnswersRepository ar;

        public AnswersService()
        {
            ar = new AnswersRepository();
        }

        public void InsertAnswer(NewAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewAnswerViewModel, Answer>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Answer a = mapper.Map<NewAnswerViewModel, Answer>(avm);
            ar.InsertAnswers(a);
        }
        public void UpdateAnswer(EditAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditAnswerViewModel, Answer>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            Answer a = mapper.Map<EditAnswerViewModel, Answer>(avm);
            ar.UpdateAnswers(a);
        }
        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            ar.UpdateAnswerVotesCount(aid, uid, value);
        }
        public void DeleteAnswer(int aid)
        {
            ar.DeleteAnswers(aid);
        }

        public List<AnswersViewModel> GetAnswersByQuestionID(int qid)
        {
            List<Answer> a = ar.GetAnswersByQuestionID(qid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answer, AnswersViewModel>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            List<AnswersViewModel> avm = mapper.Map<List<Answer>, List<AnswersViewModel>>(a);
            return avm;
        }

        public AnswersViewModel GetAnswerByAnswerID(int AnswerID)
        {
            Answer a = ar.GetAnswersByAnswerID(AnswerID).FirstOrDefault();
            AnswersViewModel avm = null;
            if (a != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answer, AnswersViewModel>(); cfg.IgnoreUnMapped(); });
                IMapper mapper = config.CreateMapper();
                avm = mapper.Map<Answer, AnswersViewModel>(a);
            }
            return avm;
        }
    }
}


