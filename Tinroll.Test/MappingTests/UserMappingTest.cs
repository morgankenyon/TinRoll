using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Model.User;
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
                 UserId = 1,
                 UserName = "morgan"
            };

            var userDto = UserMapper.ToDto(userEntity);

            Assert.Equal(userEntity.UserId, userDto.UserId);
            Assert.Equal(userEntity.UserName, userDto.UserName);
        }

        [Fact]
        public void MapUserToEntity()
        {
            var userDto = new UserDto
            {
                UserId = 1,
                UserName = "morgan"
            };

            var userEntity = UserMapper.ToEntity(userDto);

            Assert.Equal(userDto.UserId, userEntity.UserId);
            Assert.Equal(userDto.UserName, userEntity.UserName);
        }
    }
}