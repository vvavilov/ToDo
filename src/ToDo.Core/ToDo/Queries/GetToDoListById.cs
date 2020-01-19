using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Common.Extensions;
using ToDo.Core.Common.Interfaces;
using ToDo.Core.ViewModels;
using ToDo.Domain.Exceptions;
using ToDo.Domain.ToDo.Entities;

namespace ToDo.Core.ToDo.Queries
{
    public class GetToDoListById : IRequest<ToDoListVm>
    {
        public Guid Id { get; set; }
    }

    public class GetToDoListByIdValidator : AbstractValidator<GetToDoListById>
    {
        public GetToDoListByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    internal class GetToDoListByIdHandler : IRequestHandler<GetToDoListById, ToDoListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetToDoListByIdHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ToDoListVm> Handle(GetToDoListById request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.ToDoLists.FindAsyncOrThrow(request.Id);
            return _mapper.Map<ToDoListVm>(item);
        }
    }
}
