using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository;
using Xunit;

namespace TinRoll.Test.Repository
{
    public class UserRepositoryTests
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
    }
}
