using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private IBaseRepository<Question> _baseRepo;

        public QuestionRepository(IBaseRepository<Question> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _baseRepo.GetAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAndUsersAsync()
        {
            var dbQuestions = await _baseRepo.GetAsync(includeProperties: "User");
            return dbQuestions;
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            var dbQuestions = await _baseRepo.GetAsync();
            return dbQuestions;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByDateDescendingAsync()
        {
            Func<IQueryable<Question>, IOrderedQueryable<Question>> orderByFunc = x =>
                x.OrderByDescending(q => q.CreatedDate);
            var dbQuestions = await _baseRepo.GetAsync(orderBy: orderByFunc);
            return dbQuestions;
        }

        public async Task<IEnumerable<Question>> GetRecentQuestionsAsync()
        {
            Expression<Func<Question, bool>> filter = x => x.CreatedDate > DateTime.UtcNow.AddDays(-7);
            var dbQuestions = await _baseRepo.GetAsync(filter: filter);
            return dbQuestions;
        }
    }
}