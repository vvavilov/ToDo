using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Common.Behaviors;
using ToDo.Core.Common.Extensions;
using ToDo.Core.ToDo.Commands;

namespace ToDo.Core
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidators(Assembly.GetExecutingAssembly());
        }
    }
}