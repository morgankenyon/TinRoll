using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            //using OrderBy
            Func<IQueryable<Question>, IOrderedQueryable<Question>> orderByFunc = x =>
                x.OrderByDescending(q => q.CreatedDate);
            var dbQuestionsOrderBy = await _questionRepo.GetAsync(orderBy: orderByFunc);

            //using Filter
            Expression<Func<Question, bool>> filter = x => x.CreatedDate > DateTime.UtcNow.AddDays(-7);
            var dbQuestionsFilter = await _questionRepo.GetAsync(filter: filter);

            //using Include
            var dbQuestionsInclude = await _questionRepo.GetAsync(includeProperties: "User");

            //empty
            var dbQuestionsRegular = await _questionRepo.GetAsync();

            var questions = dbQuestionsOrderBy.Select(q => QuestionMapper.ToDto(q));
            return questions;
        }
    }
}
