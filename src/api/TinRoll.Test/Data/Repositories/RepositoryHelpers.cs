using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
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

            //workaround for in memory bug
            //https://github.com/aspnet/EntityFrameworkCore/issues/6872
            using (var context = new TinRollContext(options))
            {
                context.ResetValueGenerators();
                context.Database.EnsureDeleted();
            }
            return options;
        }
    }
}
