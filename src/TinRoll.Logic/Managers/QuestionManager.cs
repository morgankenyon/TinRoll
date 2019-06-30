using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Repository.Interface;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Shared;

namespace TinRoll.Logic.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository questionRepo;

        public QuestionManager(IQuestionRepository questionRepo)
        {
            this.questionRepo = questionRepo;
        }

        public Task<QuestionDto> CreateQuestionAsync(QuestionDto question)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDto> GetQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionDto>> GetQuestionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
