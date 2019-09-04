using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }
        public static User ToDb(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Username = userDto.Username,
                CreatedDate = userDto.CreatedDate,
                UpdatedDate = userDto.UpdatedDate
            };
        }
    }
}
