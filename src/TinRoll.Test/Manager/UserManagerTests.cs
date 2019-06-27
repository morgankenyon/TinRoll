using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;
using TinRoll.Logic.Managers;
using TinRoll.Shared;
using Xunit;

namespace TinRoll.Test.Manager
{
    public class UserManagerTests
    {
        [Fact]
        public void Test_CreateUser()
        {
            //dummy user to return
            var mockUser = new User
            {
                Id = 1,
                Email = "test@email.com",
                UserName = "UserName"
            };
            

            //create a mock version of the IUserRepository
            var mockUserRepo = new Mock<IUserRepository>();

            //define what we want to happen when the CreateUserAsync method is called
            mockUserRepo.Setup(u => u.CreateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(mockUser);

            //create UserManager with that Mock object
            var userManager = new UserManager(mockUserRepo.Object);

            //perform unit test
            var userToTest = new UserDto
            {
                Email = "test@email.com",
                UserName = "UserName"
            };
            var createdUser = userManager.CreateUserAsync(userToTest);

            //Assert
            Assert.Equal(1, createdUser.Id);
            mockUserRepo.Verify(u => u.CreateUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
