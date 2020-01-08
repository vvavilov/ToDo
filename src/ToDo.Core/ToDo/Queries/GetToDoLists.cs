using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetToDoListHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoListVm>> Handle(GetToDoLists request, CancellationToken cancellationToken)
        {
            var items = await _dbContext.ToDoLists.ToListAsync();
            return _mapper.Map<IEnumerable<ToDoListVm>>(items);
        }
    }
}