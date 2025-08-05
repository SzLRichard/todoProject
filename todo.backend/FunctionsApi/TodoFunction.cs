using Application.DTOs;
using Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionsApi;

public class TodoFunction
{
    private readonly ILogger<TodoFunction> _logger;

    private readonly ITodoService _todoService;

    public TodoFunction(ILogger<TodoFunction> logger,ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }

    [Function("GetAllTodoItems")]
    public IActionResult GetAllTodoItems([HttpTrigger(AuthorizationLevel.Anonymous, "get",Route ="todos")] HttpRequest req) 
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to get all todo items.");
        var items = _todoService.GetAll();

        return new OkObjectResult(items);

    }
    
    [Function("GetTodoById")]
    public IActionResult GetTodoById([HttpTrigger(AuthorizationLevel.Anonymous, "get",Route = "todos/{id}")] HttpRequest req,Guid id)
    {
        _logger.LogInformation($"C# HTTP trigger function processed a request to get todo {id}.");
        var item = _todoService.GetById(id);

        return new OkObjectResult(item);

    }

    [Function("CreateTodoItem")]
    public async Task<IActionResult> CreateTodoItem([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to add a new todo item.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createDto = JsonConvert.DeserializeObject<CreateTodoItemDTO>(requestBody);
            var created = _todoService.Create(createDto);
            return new OkObjectResult(created);
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex, "CreateTodoItem: Bad request");
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
    [Function("DeleteTodoItem")]
    public IActionResult DeleteTodoItem([HttpTrigger(AuthorizationLevel.Anonymous, "delete",Route = "todos/{id}")] HttpRequest req,Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to delete a todo item.");
        var result = _todoService.Delete(id);

        return new OkObjectResult(result);

    }
    [Function("UpdateTodoItem")]
    public async Task<IActionResult> UpdateTodoItem([HttpTrigger(AuthorizationLevel.Anonymous, "patch",Route = "todos/{id}")] HttpRequest req,Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to update a todo item.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDto = JsonConvert.DeserializeObject<UpdateTodoItemDTO>(requestBody);
            var result = _todoService.Update(id,updateDto);
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


    [Function("GetAllTodoItemsAsync")]
    public async Task<IActionResult> GetAllTodoItemsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to get all todo items.");
        var items = await  _todoService.GetAllAsync();

        return new OkObjectResult(items);

    }

    [Function("GetTodoByIdAsync")]
    public async Task<IActionResult> GetTodoByIdAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation($"C# HTTP trigger function processed a request to get todo {id}.");
        var item = await  _todoService.GetByIdAsync(id);

        return new OkObjectResult(item);

    }

    [Function("CreateTodoItemAsync")]
    public async Task<IActionResult> CreateTodoItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/todos")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to add a new todo item.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createDto = JsonConvert.DeserializeObject<CreateTodoItemDTO>(requestBody);
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
    [Function("DeleteTodoItemAsync")]
    public async Task<IActionResult> DeleteTodoItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to delete a todo item.");
        var result = await _todoService.DeleteAsync(id);

        return new OkObjectResult(result);

    }
    [Function("UpdateTodoItemAsync")]
    public async Task<IActionResult> UpdateTodoItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "v2/todos/{id}")] HttpRequest req, Guid id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request to update a todo item.");
        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateDto = JsonConvert.DeserializeObject<UpdateTodoItemDTO>(requestBody);
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