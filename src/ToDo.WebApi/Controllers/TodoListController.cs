using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.ViewModels;

namespace ToDo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListVm>>> Get()
        {
            var result = Enumerable.Range(1, 10).Select(id => new ToDoListVm {Title = $"Hello {id}"});
            return Ok(await Task.FromResult(result));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDoListVm>> Get(long id)
        {
            return Ok(await Task.FromResult(new ToDoListVm {Title = "Hello"}));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add()
        {
            await Task.CompletedTask;
            return CreatedAtAction(nameof(Get), new { id = 123 }, new ToDoListVm { Title = "Created" });
        }
    }
}