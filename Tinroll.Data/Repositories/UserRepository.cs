using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TinContext tinContext) : base(tinContext) 
        {
        }
    }
}