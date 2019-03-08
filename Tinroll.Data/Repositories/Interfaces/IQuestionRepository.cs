using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entity;

namespace Tinroll.Data.Repositories.Interfaces {
    public interface IQuestionRepository {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionAsync(Guid questionId);
        Task<int> CreateQuestionAsync(Question question);
        Task<int> UpdateQuestionAsync(Question question);
    }
}