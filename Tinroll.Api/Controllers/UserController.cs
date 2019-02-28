using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Data.Entities;
using Tinroll.Model.Question;
using Tinroll.Model.User;

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
        
        // // GET api/values
        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/user
        [HttpPost]
        public async Task<UserDto> Post(UserDto userDto)
        {
            return await _userManager.CreateUserAsync(userDto);
        }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
