using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Repository;
using TinRoll.Logic.Manager.Interface;
using TinRoll.Logic.Mapper;
using TinRoll.Shared;

namespace TinRoll.Logic.Manager
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionManager(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionDto question)
        {
            var dbQuestion = QuestionMapper.ToDb(question);
            var createdQuestion = _questionRepo.CreateQuestion(dbQuestion);
            return QuestionMapper.ToDto(createdQuestion);
        }

        public async Task<QuestionDto> GetQuestionAsync(int id)
        {
            var dbQuestion = _questionRepo.GetQuestion(id);
            return QuestionMapper.ToDto(dbQuestion);
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync()
        {
            var dbQuestions = _questionRepo.GetQuestions();
            var questions = dbQuestions.Select(q => QuestionMapper.ToDto(q));
            return questions;
        }
    }
}
