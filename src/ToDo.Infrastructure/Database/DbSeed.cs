using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Common.Interfaces;

namespace ToDo.Infrastructure.Database
{
    public class DbSeed : IDbSeed
    {
        DbContext _dbContext;
        public DbSeed(IDbContext dbContext)
        {
            DbContext? efCoreDbContext = dbContext as DbContext;

            if (efCoreDbContext == null)
            {
                throw new Exception("DbSeed supports only EfCore.DbContext");
            }
            _dbContext = efCoreDbContext;
        }

        public async Task Seed()
        {
            await _dbContext.Database.EnsureCreatedAsync();
        }
    }
}
