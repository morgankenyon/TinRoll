using System;
using System.Collections.Generic;
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

        public Task<UserDto> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
