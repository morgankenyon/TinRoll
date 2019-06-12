using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Shared;

namespace TinRoll.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TinRollContext _context;
        public UsersController(TinRollContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var dbUsers = await _context.Users.ToListAsync();
            var dtoUsers = dbUsers.Select(u => new UserDto()
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                CreatedDate = u.CreatedDate,
                UpdatedDate = u.UpdatedDate,
            });

            return dtoUsers;
        }


        [HttpPost]
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}