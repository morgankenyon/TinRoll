using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Tinroll.Business.Managers;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Dto.Entity;
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

            mockRepo.Setup(m => m.GetAllAsync())
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

            mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(user));

            var userManager = new UserManager(mockRepo.Object);

            //Act
            var userDto = await userManager.GetUserAsync(user.UserId);

            //Assert
            Assert.Equal(user.UserId, userDto.UserId);
        }
    }
}