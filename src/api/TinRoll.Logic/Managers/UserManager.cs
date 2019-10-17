using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private IBaseRepository<User> _userRepo;

        public UserManager(IBaseRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> CreateUserAsync(UserDto user)
        {
            var dbUser = user.ToDb();
            var createdUser = await _userRepo.CreateAsync(dbUser);
            return createdUser.ToDto();
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var dbUser = await _userRepo.GetAsync(id);
            return dbUser.ToDto();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var dbUsers = await _userRepo.GetAsync();
            var users = dbUsers.Select(u => u.ToDto());
            return users;
        }
    }
}
