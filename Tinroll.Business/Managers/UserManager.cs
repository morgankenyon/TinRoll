using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Question;
using Tinroll.Model.User;

namespace Tinroll.Business.Managers {
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepo;
        public UserManager(IUserRepository userRepository) {
            _userRepo = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();

            var userDtos = new List<UserDto>();
            foreach(var user in users) {
                userDtos.Add(UserMapper.ToDto(user));
            }

            return userDtos;
        }

        public async Task<UserDto> GetUserAsync(Guid userId) 
        {
            var user = await _userRepo.GetUserAsync(userId);

            return UserMapper.ToDto(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = UserMapper.ToEntity(userDto);

            user.UserId = Guid.Empty;
            var createdUser = await _userRepo.CreateUserAsync(user);

            return UserMapper.ToDto(createdUser);
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            var user = UserMapper.ToEntity(userDto);

            var updatedUser = await _userRepo.UpdateUserAsync(user);

            return UserMapper.ToDto(updatedUser);
        }
    }
}