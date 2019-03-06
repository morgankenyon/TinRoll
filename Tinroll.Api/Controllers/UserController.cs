using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;
        public UserController(IUserManager userManager) 
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get() 
        {
            return await _userManager.GetAllUsersAsync();
        }

        // GET api/user/Guid
        [HttpGet("{id}")]
        public async Task<UserDto> Get(Guid id)
        {
            return await _userManager.GetUserAsync(id);
        }

        // // POST api/user
        [HttpPost]
        public async Task Post(UserDto userDto)
        {
            await _userManager.CreateUserAsync(userDto); //TODO: return an empty 201
        }

        // PUT api/user
        [HttpPut]
        public async Task Put(UserDto userDto)
        {
            await _userManager.UpdateUserAsync(userDto); //TODO: return an empty 201
        }
    }
}
