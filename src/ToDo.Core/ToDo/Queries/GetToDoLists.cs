using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Common.Interfaces;
using ToDo.Core.ViewModels;

namespace ToDo.Core.ToDo.Queries
{
    public class GetToDoLists : IRequest<IEnumerable<ToDoListVm>>
    {
    }

    internal class GetToDoListHandler : IRequestHandler<GetToDoLists, IEnumerable<ToDoListVm>>
    {
        private readonly IDbContext _dbContext;

        public GetToDoListHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoListVm>> Handle(GetToDoLists request, CancellationToken cancellationToken)
        {
            return await _dbContext.ToDoLists
                .Select(list => new ToDoListVm
                {
                    Title = list.Title,
                    Id = list.Id
                })
                .ToListAsync();
        }
    }
}