using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Tinroll.Business.Managers;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Question;
using Tinroll.Model.User;
using Xunit;

namespace Tinroll.Test.MappingTests
{
    public class UserManagerTest
    {
        
        [Fact]
        public async Task GetAllUsersTest()
        {
            //Arrange
            IEnumerable<User> users = new List<User>() 
            {
                new User() 
                {
                    UserId = Guid.NewGuid(),
                    UserName = "joeBob"    
                },
                new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = "jimmy"
                }
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(m => m.GetAllUsersAsync())
                .Returns(Task.FromResult(users));

            var userManager = new UserManager(mockRepo.Object);

            //Act
            var userDtos = await userManager.GetAllUsersAsync();

            //Assert
            Assert.Equal(2, userDtos.Count());
            Assert.Equal(users.First().UserId, userDtos.First().UserId);
            Assert.Equal(users.Last().UserId, userDtos.Last().UserId);
        }

        [Fact]
        public async Task CreateUserTest()
        {
            //Arrange

            var user = new User() 
            {
                UserId = Guid.NewGuid(),
                UserName = "Jimmy"
            };

            var userDto = new UserDto() 
            {
                UserId = Guid.NewGuid(),
                UserName =  user.UserName
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(m => m.CreateUserAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(user));
            
            var userManager = new UserManager(mockRepo.Object);
            
            //Act            
            var createdUserDto = await userManager.CreateUserAsync(userDto);

            //Assert
            Assert.Equal(user.UserId, createdUserDto.UserId);
            Assert.Equal("Jimmy", createdUserDto.UserName);
        }
    }
}