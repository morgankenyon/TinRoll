using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Repository.Interface;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Logic.Mapper;
using TinRoll.Shared;

namespace TinRoll.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> CreateUserAsync(UserDto user)
        {
            var dbUser = UserMapper.ToDb(user);
            var createduser = await _userRepo.CreateUserAsync(dbUser);
            return UserMapper.ToDto(createduser);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var dbUser = await _userRepo.GetUserAsync(id);
            return UserMapper.ToDto(dbUser);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var dbUsers = await _userRepo.GetUsersAsync();
            var users = dbUsers.Select(u => UserMapper.ToDto(u));
            return users;
        }
    }
}
