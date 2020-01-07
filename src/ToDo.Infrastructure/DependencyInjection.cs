using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Common.Interfaces;
using ToDo.Infrastructure.Database;

namespace ToDo.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, TodoDbContext>();
            services.AddTransient<IDbSeed, DbSeed>();
        }
    }
}
