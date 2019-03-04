using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class QuestionRepository : IQuestionRepository
    {
        private TinContext _tinCon;

        public QuestionRepository(TinContext tinContext) {
            _tinCon = tinContext;
        }

        public async Task<int> CreateQuestionAsync(Question question)
        {
            await _tinCon.Questions.AddAsync(question);
            return await _tinCon.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync() => await _tinCon.Questions.ToListAsync();

        public async Task<Question> GetQuestionAsync(Guid questionId) => await _tinCon.Questions.FindAsync(questionId);

        public async Task<int> UpdateQuestionAsync(Question question)
        {
            _tinCon.Questions.Update(question);
            return await _tinCon.SaveChangesAsync();
        }
    }
}