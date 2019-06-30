using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repository.Interface
{
    public interface IQuestionRepository
    {
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> GetQuestionAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsAsync();
    }
}
