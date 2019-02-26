using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return await _tinCon.Questions.ToListAsync();
        }
    }
}