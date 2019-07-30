//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using TinRoll.Data.Entities;
//using TinRoll.Data.Repository.Interface;
//using TinRoll.Logic.Manager;
//using TinRoll.Shared;
//using Xunit;

//namespace TinRoll.Test.Manager
//{
//    public class UserManagerTests
//    {
//        [Fact]
//        public async Task Test_CreateUser()
//        {
//            //dummy user to return
//            var mockUser = new User
//            {
//                Id = 1,
//                Email = "test@email.com",
//                UserName = "UserName"
//            };
            

//            //create a mock version of the IUserRepository
//            var mockUserRepo = new Mock<IUserRepository>();

//            //define what we want to happen when the CreateUserAsync method is called
//            mockUserRepo.Setup(u => u.CreateUserAsync(It.IsAny<User>()))
//                .ReturnsAsync(mockUser);

//            //create UserManager with that Mock object
//            var userManager = new UserManager(mockUserRepo.Object);

//            //perform unit test
//            var userToTest = new UserDto
//            {
//                Email = "test@email.com",
//                UserName = "UserName"
//            };
//            var createdUser = await userManager.CreateUserAsync(userToTest);

//            //Assert
//            Assert.NotNull(createdUser);
//            Assert.Equal(1, createdUser.Id);
//            mockUserRepo.Verify(u => u.CreateUserAsync(It.IsAny<User>()), Times.Once);
//        }

//        [Fact]
//        public async Task Test_Get_User()
//        {
//            var mockUser = new User
//            {
//                Id = 1,
//                Email = "test@gmail.com",
//                UserName = "UserName"
//            };

//            var mockUserRepo = new Mock<IUserRepository>();

//            mockUserRepo.Setup(u => u.GetUserAsync(It.Is<int>(u => u == 1)))
//                .ReturnsAsync(mockUser);

//            var userManager = new UserManager(mockUserRepo.Object);

//            var user = await userManager.GetUserAsync(1);

//            Assert.NotNull(user);
//            Assert.Equal(1, user.Id);
//            mockUserRepo.Verify(u => u.GetUserAsync(It.Is<int>(u => u == 1)), Times.Once);
//        }

//        [Fact]
//        public async Task Test_Get_Users()
//        {
//            var mockUser1 = new User
//            {
//                Id = 1,
//                Email = "test@gmail.com",
//                UserName = "UserName"
//            };
//            var mockUser2 = new User
//            {
//                Id = 2,
//                Email = "test2@gmail.com",
//                UserName = "UserName2"
//            };
//            var mockUserList = new List<User>() { mockUser1, mockUser2 };

//            var mockUserRepo = new Mock<IUserRepository>();

//            mockUserRepo.Setup(u => u.GetUsersAsync())
//                .ReturnsAsync(mockUserList);

//            var userManager = new UserManager(mockUserRepo.Object);

//            var users = await userManager.GetUsersAsync();

//            Assert.NotNull(users);
//            Assert.Equal(2, users.Count());

//            var firstUser = users.First();
//            Assert.NotNull(firstUser);
//            Assert.Equal(1, firstUser.Id);

//            var secondUser = users.Last();
//            Assert.NotNull(secondUser);
//            Assert.Equal(2, secondUser.Id);
//        }
//    }
//}
