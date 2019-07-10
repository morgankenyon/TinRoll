using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;
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
            var createdQuestion = await _questionRepo.CreateAsync(dbQuestion);
            return QuestionMapper.ToDto(createdQuestion);
        }

        public async Task<QuestionDto> GetQuestionAsync(int id)
        {
            var dbQuestion = await _questionRepo.GetAsync(id);
            return QuestionMapper.ToDto(dbQuestion);
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync()
        {
            Func<IQueryable<Question>, IOrderedQueryable<Question>> orderByFunc = x =>
                x.OrderByDescending(q => q.CreatedDate);
            var dbQuestions = await _questionRepo.GetAsync(orderBy: orderByFunc);
            //var dbQuestions = await _questionRepo.GetAsync();
            //var sortedQuestions = dbQuestions.OrderByDescending(q => q.CreatedDate);
            var questions = dbQuestions.Select(q => QuestionMapper.ToDto(q));
            return questions;
        }
    }
}
