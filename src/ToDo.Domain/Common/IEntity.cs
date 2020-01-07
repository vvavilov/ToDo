using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Common
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
