using System;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;
using Xunit;

namespace Tinroll.Test.MappingTests
{

    public class UserMappingTest
    {
        [Fact]
        public void MapUserToDto()
        {
            var userEntity = new User 
            {
                 UserId = Guid.NewGuid(),
                 UserName = "morgan",
                 Email = "testEmail@gmail.com",
                 Description = "This is a test, helllo there everybody"
            };

            var userDto = UserMapper.ToDto(userEntity);

            Assert.Equal(userEntity.UserId, userDto.UserId);
            Assert.Equal(userEntity.UserName, userDto.UserName);
            Assert.Equal(userEntity.Email, userDto.Email);
            Assert.Equal(userEntity.Description, userDto.Description);
        }

        [Fact]
        public void MapUserToEntity()
        {
            var userDto = new UserDto
            {
                UserId = Guid.NewGuid(),
                UserName = "morgan",
                 Email = "testEmail@gmail.com",
                 Description = "This is a test, helllo there everybody"
            };

            var userEntity = UserMapper.ToEntity(userDto);

            Assert.Equal(userDto.UserId, userEntity.UserId);
            Assert.Equal(userDto.UserName, userEntity.UserName);
            Assert.Equal(userDto.Email, userEntity.Email);
            Assert.Equal(userDto.Description, userEntity.Description);
        }
    }
}