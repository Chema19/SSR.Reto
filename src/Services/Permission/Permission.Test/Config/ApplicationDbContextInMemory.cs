using Microsoft.EntityFrameworkCore;
using Permission.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Test.Config
{
    public static class ApplicationDbContextInMemory
    {

        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Permission.Db")
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}
