using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Core
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}