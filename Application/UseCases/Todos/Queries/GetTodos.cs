using cqrs_vanilla.Domain.Models;
using cqrs_vanilla.Domain.Ports.In;
using cqrs_vanilla.Domain.Ports.Out;

namespace cqrs_vanilla.Application.UseCases.Todos.Queries;

public record GetTodosQuery(bool? IsCompleted = false);

public record GetTodosResponse(List<Todo> Todos);

public class GetTodos : IQueryHandler<GetTodosQuery, GetTodosResponse>
{

    private readonly ITodoRepositoryRead _todoRepositoryRead;

    public GetTodos(ITodoRepositoryRead todoRepositoryRead)
    {
        _todoRepositoryRead = todoRepositoryRead;
    }

    public async Task<GetTodosResponse> Handle(GetTodosQuery query, CancellationToken cancellation)
    {
        
        var result = await _todoRepositoryRead.GetTodos(query.IsCompleted, cancellation);
        
        return new GetTodosResponse(result.ToList());
    }
}