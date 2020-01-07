using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Common
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        string LastUpdatedBy { get; set; }

        DateTimeOffset Created { get; set; }

        DateTimeOffset LastUpdated { get; set; }
    }
}
