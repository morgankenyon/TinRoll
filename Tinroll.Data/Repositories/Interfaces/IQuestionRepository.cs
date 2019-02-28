using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entities;

namespace Tinroll.Data.Repositories.Interfaces {
    public interface IQuestionRepository {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
    }
}