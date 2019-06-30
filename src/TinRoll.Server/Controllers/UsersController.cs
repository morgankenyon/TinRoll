using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinRoll.Logic.Managers.Interfaces;
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
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userManager.GetUsersAsync();
            return users;
        }


        [HttpPost]
        public async Task<UserDto> CreateUser(UserDto user)
        {
            var newUser = await _userManager.CreateUserAsync(user);
            return newUser;
        }
    }
}