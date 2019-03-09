using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IUserManager {
        Task CreateUserAsync(UserDto userDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserAsync(Guid userId);
        Task UpdateUserAsync(UserDto userDto);
    }
}