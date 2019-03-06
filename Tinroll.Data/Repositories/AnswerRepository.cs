using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {

        public AnswerRepository(TinContext tinContext) : base(tinContext)
        {
        }
    }
}