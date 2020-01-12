using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsBasedOnGeneticType(this Type type, Type geneticType)
        {
            while (type != null && type != typeof(object))
            {
                var current = type.IsGenericType
                    ? type.GetGenericTypeDefinition()
                    : type;

                if (current == geneticType)
                {
                    return true;
                }

                type = type.BaseType;
            }

            return false;
        }
    }
}
