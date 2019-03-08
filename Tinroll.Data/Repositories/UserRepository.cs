using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class UserRepository : IUserRepository
    {
        private TinContext _dbContext;
        public UserRepository(TinContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _dbContext.Users.ToListAsync();

        public async Task<User> GetUserAsync(Guid userId) => await _dbContext.Users.FindAsync(userId);

        public async Task<int> CreateUserAsync(User user) 
        {
            await _dbContext.Users.AddAsync(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync();
        }
    }
}