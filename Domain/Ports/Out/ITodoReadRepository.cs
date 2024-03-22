using cqrs_vanilla.Domain.Models;

namespace cqrs_vanilla.Domain.Ports.Out;

public interface ITodoRepositoryRead
{

    Task<Todo?> GetTodo(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Todo>> GetTodos(bool? IsCompleted, CancellationToken cancellationToken);

}
