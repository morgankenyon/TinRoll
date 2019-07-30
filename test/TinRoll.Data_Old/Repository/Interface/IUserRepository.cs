using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
