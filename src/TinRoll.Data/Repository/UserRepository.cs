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
        private IRepository<User> _baseRepo;

        public UserRepository(IRepository<User> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _baseRepo.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _baseRepo.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _baseRepo.GetAsync();
        }
    }
}
