using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class AnswerRepository : IAnswerRepository
    {
        private TinContext _tinCon;

        public AnswerRepository(TinContext tinContext) {
            _tinCon = tinContext;
        }

        public async Task<int> CreateAnswerAsync(Answer answer)
        {
            await _tinCon.Answers.AddAsync(answer);
            return await _tinCon.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync() => await _tinCon.Answers.ToListAsync();

        public async Task<Answer> GetAnswerAsync(Guid answerId) => await _tinCon.Answers.FindAsync(answerId);

        public async Task<int> UpdateAnswerAsync(Answer answer)
        {
            _tinCon.Answers.Update(answer);
            return await _tinCon.SaveChangesAsync();
        }
    }
}