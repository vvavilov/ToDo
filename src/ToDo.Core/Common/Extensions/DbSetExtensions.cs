using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Exceptions;

namespace ToDo.Core.Common.Extensions
{
    public static class DbSetExtensions
    {
        public async static Task<TEntity> FindAsyncOrThrow<TEntity>(this DbSet<TEntity> dbSet, params object[] keyValues) where TEntity : class
        {
            var entity = await dbSet.FindAsync(keyValues);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity), keyValues);
            }

            return entity;
        }
    }
}
