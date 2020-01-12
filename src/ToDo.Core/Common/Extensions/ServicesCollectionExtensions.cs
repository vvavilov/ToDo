using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ToDo.Core.Common.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddValidators(this IServiceCollection services, params Assembly[] validatorsAssemblies)
        {
            var validators = new List<(Type validatableType, Type validator)>();

            var definedValidators = validatorsAssemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsPublic
                    && !type.IsAbstract
                    && GetValidatorInterface(type) != null);

            foreach (var validator in definedValidators)
            {
                var typeValidatorIsDefinedFor = GetValidatorInterface(validator).GetGenericArguments()[0];
                var baseValidatorDefinition = typeof(IValidator<>).MakeGenericType(typeValidatorIsDefinedFor);
                services.AddTransient(baseValidatorDefinition, validator);
            }
        }

        private static Type GetValidatorInterface(Type validator)
        {
            return validator.GetInterfaces().FirstOrDefault(validatorInterface => 
                validatorInterface.IsGenericType
                && validatorInterface.GetGenericTypeDefinition() == typeof(IValidator<>));
        }
    }
}
