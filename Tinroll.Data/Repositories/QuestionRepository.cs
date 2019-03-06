using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(TinContext tinContext) : base(tinContext) 
        {
        }
    }
}