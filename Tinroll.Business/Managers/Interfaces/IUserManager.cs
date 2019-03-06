using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entities;
using Tinroll.Model.Question;
using Tinroll.Model.User;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IUserManager {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(Guid userId);
        Task CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
    }
}