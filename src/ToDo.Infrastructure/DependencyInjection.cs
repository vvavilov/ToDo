using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToDo.Core.Common.Interfaces;
using ToDo.Infrastructure.Auth;
using ToDo.Infrastructure.Database;
using ToDo.WebApi.Configuration;

namespace ToDo.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbSeed, DbSeed>();
            services.AddTransient<ICurrentUser, CurrentUser>();

            services.AddDbContext<IDbContext, TodoDbContext>(options =>
            {
                var sqlServerOptions = new SqlServerOptions();
                configuration.Bind("SqlServer", sqlServerOptions);
                options.UseSqlServer(sqlServerOptions.ConnectionString);
            });
        }
    }
}
