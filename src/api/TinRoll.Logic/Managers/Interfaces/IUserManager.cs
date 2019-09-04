using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<UserDto> CreateUserAsync(UserDto user);
        Task<UserDto> GetUserAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}
