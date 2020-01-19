using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.WebApi.Middleware;

namespace ToDo.WebApi.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
