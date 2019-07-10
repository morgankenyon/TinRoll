using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;

namespace TinRoll.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TinRollContext context) : base(context)
        { }
    }
}
