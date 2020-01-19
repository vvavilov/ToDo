using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        [ProducesResponseType(typeof(IEnumerable<ToDoListVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToDoListVm>>> GetAll()
        {
            var lists = await _mediatr.Send(new GetToDoLists());
            return Ok(lists);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ToDoListVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoListVm>> GetById(Guid id)
        {
            var item = await _mediatr.Send(new GetToDoListById
            {
                Id = id
            });

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ToDoListVm), StatusCodes.Status201Created)]
        public async Task<ActionResult<ToDoListVm>> Add([FromBody]AddToDoList addToDoListCommand)
        {
            var addedEntity = await _mediatr.Send(addToDoListCommand);
            return CreatedAtAction(nameof(GetById), new { id = addedEntity.Id }, addedEntity);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ToDoListVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ToDoListVm>> Update([FromBody] UpdateToDoList updateToDoListCommand)
        {
            var updatedItem = await _mediatr.Send(updateToDoListCommand);

            return Ok(updatedItem);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteToDoList { Id = id });
            return Ok();
        }
    }
}