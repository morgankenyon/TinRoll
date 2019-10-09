using System.Collections.Generic;
using System.Threading.Tasks;

using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers.Interfaces
{
    public interface IQuestionManager
    {
        Task<QuestionDto> CreateQuestionAsync(CreateQuestionDto question);
        Task<QuestionDto> GetQuestionAsync(int id);
        Task<IEnumerable<QuestionDto>> GetQuestionsAsync();
    }
}
