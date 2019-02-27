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
                    UserId = 1,
                    UserName = "joeBob"    
                },
                new User()
                {
                    UserId = 2,
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
            Assert.Equal(1, userDtos.First().UserId);
            Assert.Equal(2, userDtos.Last().UserId);
        }
    }
}