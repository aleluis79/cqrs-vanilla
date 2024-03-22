using cqrs_vanilla.Domain.Ports.Out;
using cqrs_vanilla.Infrastructure.Services;

namespace cqrs_vanilla.Application.UseCases.Todos.Commands;

public record UpdateTodoCommand(int Id, string Name, string Description, bool IsCompleted);

public record UpdateTodoResponse(bool Success);

public class UpdateTodo : ICommandHandler<UpdateTodoCommand, UpdateTodoResponse>
{
    private readonly ITodoRepositoryWrite _todoRepositoryWrite;
    public UpdateTodo(ITodoRepositoryWrite todoRepositoryWrite)
    {
        _todoRepositoryWrite = todoRepositoryWrite;
    }

    public async Task<UpdateTodoResponse> Handle(UpdateTodoCommand command, CancellationToken cancellation)
    {
        var result = await _todoRepositoryWrite.UpdateTodo(command);
        return new UpdateTodoResponse(result);
    }
}
