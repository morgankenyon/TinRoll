using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository;
using Xunit;

namespace TinRoll.Test.Repository
{
    public class UserRepositoryTests : RepositoryTest
    {

        [Fact]
        public async Task Test_Create_User()
        {
            var options = new DbContextOptionsBuilder<TinRollContext>()
                .UseInMemoryDatabase(databaseName: "Create_User")
                .Options;
            
            var newUser = new User
            {
                Email = "test@email.com",
                UserName = "userName"
            };
            
            User dbUser = null;
            //create user in memory database
            using (var context = new TinRollContext(options))
            {
                var userRepository = new UserRepository(context);
                dbUser = await userRepository.CreateUserAsync(newUser);
            }
            
            Assert.NotNull(dbUser);
            Assert.Equal(1, dbUser.Id);
            //check to make sure it exists
            using (var context = new TinRollContext(options))
            {
                var userCount = await context.Users.CountAsync();
                Assert.Equal(1, userCount);
            }
        }

        [Fact]
        public async Task Test_GetUser()
        {
            var options = new DbContextOptionsBuilder<TinRollContext>()
                .UseInMemoryDatabase(databaseName: "Get_User")
                .Options;

            var userToGet = new User
            {
                Email = "test@gmail.com",
                UserName = "userName"
            };

            //create user to fetch
            using (var context = new TinRollContext(options))
            {
                context.Users.Add(userToGet);
                context.SaveChanges();
            }


            //test get user
            User dbUser = null;
            using (var context = new TinRollContext(options))
            {
                var userRepo = new UserRepository(context);
                dbUser = await userRepo.GetUserAsync(userToGet.Id);
            }

            Assert.NotNull(dbUser);
            Assert.Equal(userToGet.Id, dbUser.Id);
        }

        [Fact]
        public async Task Test_Get_Users()
        {
            var options = BuildInMemoryDatabase("Get_Users");

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

            //create questions to fetch
            using (var context = new TinRollContext(options))
            {
                context.Users.Add(userToGet);
                context.Users.Add(userToGet2);
                context.SaveChanges();
            }

            //test get questions
            IEnumerable<User> dbUsers = null;
            using (var context = new TinRollContext(options))
            {
                var userRepo = new UserRepository(context);
                dbUsers = await userRepo.GetUsersAsync();
            }

            Assert.NotNull(dbUsers);
            Assert.Equal(2, dbUsers.Count());
        }
    }
}
