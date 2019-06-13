using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Logic.Commands;
using Xunit;

namespace TinRoll.Test.Logic.CommandTests
{
    public class CreateUserHandlerTests
    { 
        [Fact]
        public async Task TestCreateUserCommandHandler()
        {
            var options = new DbContextOptionsBuilder<TinRollContext>()
                .UseInMemoryDatabase(databaseName: "Add_User")
                .Options;

            var newUser = new User
            {
                Email = "test@email.com",
                UserName = "userName"
            };

            int? userId = null;
            //create user in memory database
            using (var context = new TinRollContext(options))
            {
                var createUserHandler = new CreateUserCommandHandler(context);
                var createUserCommand = new CreateUserCommand(newUser);
                userId = await createUserHandler.Handle(createUserCommand);
            }

            Assert.NotNull(userId);
            //check to make sure it exists
            using (var context = new TinRollContext(options))
            {
                var userCount = await context.Users.CountAsync();
                Assert.Equal(1, userCount);
            }
        }
    }
}
