using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Common.Interfaces;

namespace ToDo.Infrastructure.Auth
{
    public class CurrentUser : ICurrentUser
    {
        public string Email => "Administrator@gmail.com";
    }
}
