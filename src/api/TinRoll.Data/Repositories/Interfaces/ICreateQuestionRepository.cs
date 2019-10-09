using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repositories.Interfaces
{
    public interface ICreateQuestionRepository
    {
        Task CreateQuestionAsync(Question question, IEnumerable<int> TagIds);
    }
}
