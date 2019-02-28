using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _tinCon.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User user) 
        {
            await _tinCon.Users.AddAsync(user);
            await _tinCon.SaveChangesAsync();
            return user;
        }
    }
}