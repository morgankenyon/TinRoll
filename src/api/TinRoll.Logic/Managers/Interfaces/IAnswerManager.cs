using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers.Interfaces
{
    public interface IAnswerManager
    {
        Task<AnswerDto> CreateAnswerAsync(AnswerDto answer);
        Task<AnswerDto> GetAnswerAsync(int id);
        Task<IEnumerable<AnswerDto>> GetAnswersAsync();
    }
}
