using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Common.Interfaces;
using ToDo.Domain.Common;
using ToDo.Domain.ToDo.Entities;

namespace ToDo.Infrastructure.Database
{
    public class TodoDbContext : DbContext, IDbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ToDoList> ToDoLists { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var auditableEntity = entry.Entity as IAuditable;

                if(auditableEntity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        auditableEntity.Created = DateTimeOffset.Now;
                        auditableEntity.CreatedBy = "Creation Admin";
                    }

                    if(entry.State == EntityState.Modified)
                    {
                        auditableEntity.LastUpdated = DateTimeOffset.Now;
                        auditableEntity.LastUpdatedBy = "Updating Admin";
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
