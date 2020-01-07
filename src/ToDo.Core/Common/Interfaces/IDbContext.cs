using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Domain.ToDo.Entities;

namespace ToDo.Core.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<ToDoList> ToDoLists { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
