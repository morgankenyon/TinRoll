using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsAsync();
    }
}
