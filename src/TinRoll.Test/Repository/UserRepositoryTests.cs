using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository;
using TinRoll.Data.Repository.Interface;
using Xunit;

namespace TinRoll.Test.Repository
{
    public class UserRepositoryTests : RepositoryTest
    {

        [Fact]
        public async Task Test_Create_User()
        {
            
            var newUser = new User
            {
                Id = 1,
                Email = "test@email.com",
                UserName = "userName"
            };

            var mockBaseRepo = new Mock<IRepository<User>>();

            mockBaseRepo.Setup(m => m.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(newUser);
            
            var userRepository = new UserRepository(mockBaseRepo.Object);
            var dbUser = await userRepository.CreateUserAsync(newUser);
            
            Assert.NotNull(dbUser);
            Assert.Equal(1, dbUser.Id);
        }

        [Fact]
        public async Task Test_GetUser()
        {
            var userToGet = new User
            {
                Id = 1,
                Email = "test@gmail.com",
                UserName = "userName"
            };

            var mockBaseRepo = new Mock<IRepository<User>>();

            mockBaseRepo.Setup(m => m.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(userToGet);

            var userRepo = new UserRepository(mockBaseRepo.Object);
            var dbUser = userRepo.GetUserAsync(userToGet.Id);

            Assert.NotNull(dbUser);
            Assert.Equal(userToGet.Id, dbUser.Id);
        }

        [Fact]
        public async Task Test_Get_Users()
        {
            var userToGet = new User
            {
                Email = "test@gmail.com",
                UserName = "userName"
            };
            var userToGet2 = new User
            {
                Email = "test2@gmail.com",
                UserName = "userName"
            };
            var usersToGet = new List<User>() { userToGet, userToGet2 };


            var mockBaseRepo = new Mock<IRepository<User>>();

            mockBaseRepo.Setup(m => m.GetAsync(null, null, null))
                .ReturnsAsync(usersToGet);
            //test get questions

            var userRepo = new UserRepository(mockBaseRepo.Object);
            var dbUsers = await userRepo.GetUsersAsync();

            Assert.NotNull(dbUsers);
            Assert.Equal(2, dbUsers.Count());
        }
    }
}
