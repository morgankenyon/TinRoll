using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinRoll.Logic.Manager;
using TinRoll.Shared;

namespace TinRoll.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userManager.GetUsers();
            return users;
        }


        [HttpPost]
        public UserDto CreateUser(UserDto user)
        {
            var newUser = _userManager.CreateUser(user);
            return newUser;
        }
    }
}