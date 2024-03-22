using cqrs_vanilla.Domain.Ports.Out;
using cqrs_vanilla.Infrastructure.Services;

namespace cqrs_vanilla.Application.UseCases.Todos.Commands;

public record CreateTodoCommand(string Name, string Description);

public record CreateTodoResponse(bool Success);

public class CreateTodo : ICommandHandler<CreateTodoCommand, CreateTodoResponse>
{
    private readonly ITodoRepositoryWrite _todoRepositoryWrite;
    public CreateTodo(ITodoRepositoryWrite todoRepositoryWrite)
    {
        _todoRepositoryWrite = todoRepositoryWrite;
    }

    public async Task<CreateTodoResponse> Handle(CreateTodoCommand command, CancellationToken cancellation)
    {
        var result = await _todoRepositoryWrite.CreateTodo(command);
        return new CreateTodoResponse(result);
    }
}
