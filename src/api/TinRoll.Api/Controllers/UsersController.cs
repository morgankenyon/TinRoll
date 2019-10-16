using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinRoll.Api.ApiErrors;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Shared.Dtos;

namespace TinRoll.Api.Controllers
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _userManager.GetUserAsync(id);

            if (user == null)
            {
                return NotFound(new NotFoundError("The user was not found"));
            }

            return Ok(user);
        }


        [HttpPost]
        public async Task<UserDto> CreateUser(UserDto user)
        {
            var newUser = await _userManager.CreateUserAsync(user);
            return newUser;
        }
    }
}