using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entities;

namespace Tinroll.Data.Repositories.Interfaces {
    public interface IUserRepository {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
    }
}