using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Common.Interfaces;
using ToDo.Core.ViewModels;
using ToDo.Domain.ToDo.Entities;

namespace ToDo.Core.ToDo.Commands
{
    public class AddToDoList : IRequest<ToDoListVm>
    {
        public string Title { get; set; }
    }

    internal class AddToDoListHandler : IRequestHandler<AddToDoList, ToDoListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddToDoListHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ToDoListVm> Handle(AddToDoList request, CancellationToken cancellationToken)
        {
            var listToAdd = new ToDoList
            {
                Title = request.Title
            };

            _dbContext.ToDoLists.Add(listToAdd);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ToDoListVm>(listToAdd);
        }
    }
}
