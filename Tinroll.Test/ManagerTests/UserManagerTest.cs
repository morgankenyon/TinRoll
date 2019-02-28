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
        public async Task GetUserTest()
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                UserName = "jimmyjohns@restaurant.com"
            };

            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(m => m.GetUserAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(user));

            var userManager = new UserManager(mockRepo.Object);

            //Act
            var userDto = await userManager.GetUserAsync(user.UserId);

            //Assert
            Assert.Equal(user.UserId, userDto.UserId);
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
        }

        [Fact]
        public async Task UpdateUserTest() 
        {
            //Arrange

            var user = new User() 
            {
                UserId = Guid.NewGuid(),
                UserName = "Jimmy",
                Email = "morgan@gmail.com",
                Description = "description test"
            };

            var userDto = new UserDto() 
            {
                UserId = user.UserId,
                UserName =  user.UserName,
                Email = user.Email,
                Description = "Worst Description"
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(m => m.UpdateUserAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(user));
            
            var userManager = new UserManager(mockRepo.Object);

            //Act
            var updatedUserDto = await userManager.UpdateUserAsync(userDto);

            //Assert
            Assert.Equal(user.UserId, updatedUserDto.UserId);
            Assert.Equal(user.Description, updatedUserDto.Description);
        }
    }
}