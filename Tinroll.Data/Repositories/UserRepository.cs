using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class UserRepository : IUserRepository
    {
        private TinContext _tinCon;

        public UserRepository(TinContext tinContext) {
            _tinCon = tinContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _tinCon.Users.ToListAsync();

        public async Task<User> GetUserAsync(Guid userId) => await _tinCon.Users.FindAsync(userId);

        public async Task<int> CreateUserAsync(User user) 
        {
            await _tinCon.Users.AddAsync(user);
            return await _tinCon.SaveChangesAsync();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            _tinCon.Users.Update(user);
            return await _tinCon.SaveChangesAsync();
        }
    }
}