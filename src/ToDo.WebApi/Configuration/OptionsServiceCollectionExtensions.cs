using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.WebApi.Configuration
{
    public static class OptionsServiceCollectionExtensions
    {
        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerOptions>(configuration.GetSection("CosmosDb"));
        }
    }
}
