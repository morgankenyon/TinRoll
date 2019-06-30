using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;

namespace TinRoll.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TinRollContext context;
        public UserRepository(TinRollContext context)
        {
            this.context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }
    }
}
