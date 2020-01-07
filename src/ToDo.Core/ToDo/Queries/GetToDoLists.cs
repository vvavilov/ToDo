using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDo.Core.ViewModels;

namespace ToDo.Core.ToDo.Queries
{
    public class GetToDoLists : IRequest<IEnumerable<ToDoListVm>>
    {
    }

    internal class ToDoHandler : IRequestHandler<GetToDoLists, IEnumerable<ToDoListVm>>
    {
        public Task<IEnumerable<ToDoListVm>> Handle(GetToDoLists request, CancellationToken cancellationToken)
        {
            var lists = Enumerable.Range(1, 5).Select(i => new ToDoListVm {Title = $"Item: {i}"});
            return Task.FromResult<IEnumerable<ToDoListVm>>(lists);
        }
    }
}