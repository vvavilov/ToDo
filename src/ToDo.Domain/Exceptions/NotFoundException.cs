using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ToDo.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Type entityType, Guid entityId)
            : base($"Entity of {entityType} type with {entityId} id is not found")
        {
        }

        public NotFoundException(Type entityType, object[] keys)
            : base($"Entity of {entityType} type with {JsonSerializer.Serialize(keys)} is not found")
        {
        }

        public NotFoundException()
        {
        }
    }
}
