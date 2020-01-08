using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.ToDo.Commands;
using ToDo.Core.ToDo.Queries;
using ToDo.Core.ViewModels;

namespace ToDo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TodoListController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListVm>>> Get()
        {
            var lists = await _mediatr.Send(new GetToDoLists());
            return Ok(lists);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDoListVm>> Get(Guid id)
        {
            var item = await _mediatr.Send(new GetToDoListById
            {
                Id = id
            });

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add()
        {
            var addedEntity = await _mediatr.Send(new AddToDoList { Title = "New List" });
            return CreatedAtAction(nameof(Get), new { id = addedEntity.Id }, addedEntity);
        }
    }
}