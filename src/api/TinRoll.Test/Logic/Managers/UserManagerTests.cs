using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.Managers
{
    public class UserManagerTests
    {
        [Fact]
        public async Task Test_Create_User()
        {
            var mockUser = new User
            {
                Id = 1
            };

            var mockUserRepo = new Mock<IBaseRepository<User>>();

            mockUserRepo.Setup(a => a.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(mockUser);

            var userManager = new UserManager(mockUserRepo.Object);

            var userToTest = new UserDto();

            var createdUser = await userManager.CreateUserAsync(userToTest);

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().Be(1);
            mockUserRepo.Verify(u => u.CreateAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_User()
        {
            var mockUser = new User
            {
                Id = 1
            };

            var mockUserRepo = new Mock<IBaseRepository<User>>();

            mockUserRepo.Setup(a => a.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(mockUser);

            var userManager = new UserManager(mockUserRepo.Object);

            var user = await userManager.GetUserAsync(1);

            user.Should().NotBeNull();
            user.Id.Should().Be(1);
            mockUserRepo.Verify(u => u.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Users()
        {
            var mockUsers = new List<User>
            {
                new User
                {
                    Id = 1
                },
                new User
                {
                    Id = 2
                }
            };

            var mockUserRepo = ManagerHelpers.MockRepoGetAsync(mockUsers);

            var userManager = new UserManager(mockUserRepo.Object);

            var users = await userManager.GetUsersAsync();

            users.Should().HaveCount(2);
            users.First().Id.Should().Be(1);
            users.Skip(1).First().Id.Should().Be(2);
            ManagerHelpers.VerifyGetAsync(mockUserRepo, Times.Once());
        }
    }
}
