using Application.DTOs;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ITodoService _todoService;

        public TodoController(ILogger<WeatherForecastController> logger,ITodoService todoService) {
            _logger = logger;
            _todoService = todoService;
        }


        [HttpGet("todos")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Processed a request to get all todo items.");
            var items = await _todoService.GetAllAsync();

            return new OkObjectResult(items);

        }

        [HttpGet("todos/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation($"Processed a request to get todo {id}.");
            var item = await _todoService.GetByIdAsync(id);

            return new OkObjectResult(item);

        }

        [HttpPost("todos")]
        public async Task<IActionResult> Create([FromBody] CreateTodoItemDTO createDto)
        {
            _logger.LogInformation("Processed a request to add a new todo item.");
            try
            {
                var created = await _todoService.CreateAsync(createDto);
                return new OkObjectResult(created);
            }
            catch (ValidationException ex)
            {
                return new BadRequestObjectResult(ex.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                return new ObjectResult(new
                {
                    Error = "An unexpected error occurred.",
                    Message = ex.Message
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
        [HttpDelete("todos/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Processed a request to delete a todo item.");
            var result = await _todoService.DeleteAsync(id);

            return new OkObjectResult(result);

        }
        [HttpPatch("todos/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoItemDTO updateDto)
        {
            _logger.LogInformation("Processed a request to update a todo item.");
            try
            {
                var result = await _todoService.UpdateAsync(id, updateDto);
                return new OkObjectResult(result);
            }
            catch (ValidationException ex)
            {
                return new BadRequestObjectResult(ex.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                return new ObjectResult(new
                {
                    Error = "An unexpected error occurred.",
                    Message = ex.Message
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

        }

    }
}
