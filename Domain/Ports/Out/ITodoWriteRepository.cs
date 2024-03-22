using cqrs_vanilla.Application.UseCases.Todos.Commands;

namespace cqrs_vanilla.Domain.Ports.Out;

public interface ITodoRepositoryWrite
{
    Task<bool> CreateTodo(CreateTodoCommand todo);

    Task<bool> UpdateTodo(UpdateTodoCommand todo);

    Task<bool> DeleteTodo(int id);

}
