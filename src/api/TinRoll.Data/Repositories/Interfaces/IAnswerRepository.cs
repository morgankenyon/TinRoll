using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> CreateAnswerAsync(Answer answer);
        Task<Answer> GetAnswerAsync(int id);
        Task<IEnumerable<Answer>> GetAnswersAsync();
    }
}
