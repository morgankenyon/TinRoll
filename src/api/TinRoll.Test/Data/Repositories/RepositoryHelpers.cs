using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinRoll.Data;

namespace TinRoll.Test.Data.Repositories
{
    public static class RepositoryHelpers
    {
        public static DbContextOptions<TinRollContext> BuildInMemoryDatabaseOptions(string databaseName)
        {
            var options = new DbContextOptionsBuilder<TinRollContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            return options;
        }
    }
}
