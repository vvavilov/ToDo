using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Common.Extensions;
using ToDo.Core.Common.Interfaces;

namespace ToDo.Core.ToDo.Commands
{
    public class DeleteToDoList : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteToDoListValidator : AbstractValidator<DeleteToDoList>
    {
        public DeleteToDoListValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public class DeleteToDoListHandler : AsyncRequestHandler<DeleteToDoList>
    {
        private readonly IDbContext _dbContext;

        public DeleteToDoListHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(DeleteToDoList request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _dbContext.ToDoLists.FindAsyncOrThrow(request.Id);
            _dbContext.ToDoLists.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
