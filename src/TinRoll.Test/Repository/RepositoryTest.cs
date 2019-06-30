using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data;

namespace TinRoll.Test.Repository
{
    public abstract class RepositoryTest
    {
        protected DbContextOptions<TinRollContext> BuildInMemoryDatabase(string databaseName)
        {
            var options = new DbContextOptionsBuilder<TinRollContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            return options;
        }
    }
}
