using System;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers {
    public class AnswerManager : IAnswerManager
    {
        public Task CreateUserAsync(AnswerDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<AnswerDto>> GetAllAnswersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnswerDto> GetAnswerAsync(Guid answerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(AnswerDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}