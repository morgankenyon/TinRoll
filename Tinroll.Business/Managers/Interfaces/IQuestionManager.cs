using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entities;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IQuestionManager {
        Task<IEnumerable<Question>> GetAllQuestions();
    }
}