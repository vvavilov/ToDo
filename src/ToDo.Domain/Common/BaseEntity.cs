using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Common
{
    public abstract class BaseEntity : IAuditable, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset LastUpdated { get; set; }
    }
}
