using cqrs_vanilla.Application.UseCases.Todos.Commands;
using cqrs_vanilla.Application.UseCases.Todos.Queries;
using cqrs_vanilla.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_vanilla.Infrastructure.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public TodoController(ILogger<TodoController> logger, ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        _logger.LogInformation("ping method called");
        return Ok("pong");
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken, bool? isCompleted = null)
    {
        _logger.LogInformation("get method called");
        var query = new GetTodosQuery(isCompleted);
        var result = await _queryDispatcher.Dispatch<GetTodosQuery, GetTodosResponse>(query, cancellationToken);
        
        return Ok(result.Todos);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTodoCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("post method called");
        var result = await _commandDispatcher.Dispatch<CreateTodoCommand, CreateTodoResponse>(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("put method called");
        var result = await _commandDispatcher.Dispatch<UpdateTodoCommand, UpdateTodoResponse>(command, cancellationToken);
        return Ok(result);
    }

}
