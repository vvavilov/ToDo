using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Infrastructure.Database;

namespace ToDo.WebApi.Extensions
{
    public static class DbSeed
    {
        public static async Task SeedDb(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dbSeed = scope.ServiceProvider.GetService<IDbSeed>();
            await dbSeed.Seed();
        }
    }
}
