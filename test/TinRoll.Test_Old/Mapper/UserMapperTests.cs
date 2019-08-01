//using System;
//using TinRoll.Data.Entities;
//using TinRoll.Logic.Mapper;
//using TinRoll.Shared;
//using Xunit;

//namespace TinRoll.Test.Mapping
//{
//    public class UserMapperTests
//    {
//        [Fact]
//        public void Test_User_To_UserDto()
//        {
//            //arrange
//            var user = new User
//            {
//                Id = 1,
//                CreatedDate = DateTime.UtcNow,
//                Email = "testEmail1",
//                UpdatedDate = DateTime.UtcNow,
//                UserName = "testUsername"
//            };

//            //act
//            var userDto = UserMapper.ToDto(user);

//            //assert
//            Assert.NotNull(userDto);
//            Assert.Equal(user.Id, userDto.Id);
//            Assert.Equal(user.CreatedDate, userDto.CreatedDate);
//            Assert.Equal(user.Email, userDto.Email);
//            Assert.Equal(user.UpdatedDate, userDto.UpdatedDate);
//            Assert.Equal(user.UserName, userDto.UserName);
//        }

//        [Fact]
//        public void Test_UserDto_To_User()
//        {
//            //arrange
//            var userDto = new UserDto
//            {
//                Id = 1,
//                CreatedDate = DateTime.UtcNow,
//                Email = "testEmail1",
//                UpdatedDate = DateTime.UtcNow,
//                UserName = "testUsername"
//            };

//            //act
//            var user = UserMapper.ToDb(userDto);

//            //assert
//            Assert.NotNull(userDto);
//            Assert.Equal(userDto.Id, user.Id);
//            Assert.Equal(userDto.CreatedDate, user.CreatedDate);
//            Assert.Equal(userDto.Email, user.Email);
//            Assert.Equal(userDto.UpdatedDate, user.UpdatedDate);
//            Assert.Equal(userDto.UserName, user.UserName);
//        }
//    }
//}
