using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Common.Interfaces;
using ToDo.Infrastructure.Database;

namespace ToDo.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<IDbContext, TodoDbContext>();
            services.AddTransient<IDbSeed, DbSeed>();
            services.AddDbContext<IDbContext, TodoDbContext>(opts =>
            {
                opts.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                databaseName: "OrdersDB");
            });
        }
    }
}
