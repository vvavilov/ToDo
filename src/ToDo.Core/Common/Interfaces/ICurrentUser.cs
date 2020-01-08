using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Core.Common.Interfaces
{
    public interface ICurrentUser
    {
        string Email { get; }
    }
}
