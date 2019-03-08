using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entity;

namespace Tinroll.Data.Repositories.Interfaces {
    public interface IUserRepository {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        Task<int> CreateUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
    }
}