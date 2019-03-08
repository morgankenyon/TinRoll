using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entity;

namespace Tinroll.Data.Repositories.Interfaces {
    public interface IAnswerRepository {
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task<Answer> GetAnswerAsync(Guid answerId);
        Task<int> CreateAnswerAsync(Answer answer);
        Task<int> UpdateAnswerAsync(Answer answer);
    }
}