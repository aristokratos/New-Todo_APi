using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApi;
using NewApi.Data;
using NewApi.Models;

namespace WebApiTodo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoApiDbContext dbContext;
        private List<ToDo> Todos;

        public ToDoController(ToDoApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{page}")]
        public async Task<IActionResult> GetToDos(int page)
        {
            if(dbContext.ToDo == null)
                return NotFound();


            var pageResults = 3f;
            var pageCount = Math.Ceiling(dbContext.ToDo.Count() / pageResults);

            return Ok(await dbContext.ToDo
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync());

            var response = new TodoResponseDto
            {
                toDos = Todos,
                CurrentPage = page,
                Pages = (int)pageCount,
            };
           
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetToDo([FromRoute] Guid id)
        {
            var result = await dbContext.ToDo.FindAsync(id);

            if(result == null)
            {
                return NotFound();


            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{Email:guid}")]
        public async Task<IActionResult> GetContactEmail([FromRoute] Guid email)
        {
            var contact = await dbContext.ToDo.FindAsync(email);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoRequest addTodoRequest)
        {
            var ToDo = new ToDo()
            {
                Id = Guid.NewGuid(),
                FullName = addTodoRequest.FullName,
                Address = addTodoRequest.Address,
                EmailAddress = addTodoRequest.EmailAddress,
                Item = addTodoRequest.Item,
                CreatedOn = addTodoRequest.CreatedOn,
                ExpiresOn = addTodoRequest.ExpiresOn,
                Phone = addTodoRequest.Phone,

            };

           await dbContext.ToDo.AddAsync(ToDo);
            await dbContext.SaveChangesAsync();

            return Ok(ToDo);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateToDo([FromRoute] Guid id, UpdateTodoRequest updateTodoRequest)
        {
           var result = await dbContext.ToDo.FindAsync(id);

            if(result != null)
            {
                result.FullName = updateTodoRequest.FullName;
                result.Address = updateTodoRequest.Address;
                result.EmailAddress = updateTodoRequest.EmailAddress;
                result.Item = updateTodoRequest.Item;
                result.CreatedOn = updateTodoRequest.CreatedOn;
                result.ExpiresOn = updateTodoRequest.ExpiresOn;
                result.Phone = updateTodoRequest.Phone;

               await dbContext.SaveChangesAsync();

                return Ok(result);
            }
            return NotFound("Invalid input!");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] Guid id)
        {
            var result = await dbContext.ToDo.FindAsync(id);

            if(result != null)
            {
                dbContext.Remove(result);
               await dbContext.SaveChangesAsync();

                return Ok("Successfully deleted");

            }
            return BadRequest("Invalid input!");


        }

    }

}
