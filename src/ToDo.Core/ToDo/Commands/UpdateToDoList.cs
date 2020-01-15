using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Core.Common.Interfaces;
using ToDo.Core.ViewModels;

namespace ToDo.Core.ToDo.Commands
{
    public class UpdateToDoList : IRequest<ToDoListVm>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateToDoListValidator : AbstractValidator<UpdateToDoList>
    {
        public UpdateToDoListValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }

    public class UpdateToDoListHandler : IRequestHandler<UpdateToDoList, ToDoListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _db;

        public UpdateToDoListHandler(IMapper mapper, IDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ToDoListVm> Handle(UpdateToDoList request, CancellationToken cancellationToken)
        {
            var entityToUpdate = _db.ToDoLists.Find(request.Id);
            entityToUpdate.Title = request.Title;
            await _db.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ToDoListVm>(entityToUpdate);
        }
    }
}
