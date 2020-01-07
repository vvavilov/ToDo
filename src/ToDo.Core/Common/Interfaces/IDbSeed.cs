using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Common.Interfaces;

namespace ToDo.Infrastructure.Database
{
    public interface IDbSeed
    {
        Task Seed();
    }
}
