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
        private readonly ICurrentUser _user;

        public TodoDbContext(DbContextOptions options, ICurrentUser user) : base(options) {
            _user = user;
        }

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
                        auditableEntity.CreatedBy = _user.Email;
                    }

                    if(entry.State == EntityState.Modified)
                    {
                        auditableEntity.LastUpdated = DateTimeOffset.Now;
                        auditableEntity.LastUpdatedBy = _user.Email;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
