
using cqrs_vanilla.Application.UseCases.Todos.Commands;
using cqrs_vanilla.Domain.Ports.Out;
using cqrs_vanilla.Infraestructure.Entities;
using cqrs_vanilla.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vanilla.Infraestructure.Repositories;

public class TodoRepositoryWrite : ITodoRepositoryWrite
{
    private readonly ApplicationDbContext _context;

    public TodoRepositoryWrite(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> CreateTodo(CreateTodoCommand todo)
    {
        var id = _context.Todos.Count() + 1;

        _context.Todos.Add(new TodoEntity {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = false
        });

        _context.SaveChanges();

        return Task.FromResult(true);
    }

    public Task<bool> DeleteTodo(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            return Task.FromResult(false);
        }
        _context.Todos.Remove(todo);

        _context.SaveChanges();

        return Task.FromResult(true);
    }

    public Task<bool> UpdateTodo(UpdateTodoCommand todo)
    {
        var todoAux = _context.Todos.AsNoTracking().Where(x => x.Id == todo.Id).FirstOrDefault();
        if (todoAux == null)
        {
            return Task.FromResult(false);
        }

        _context.Todos.Update(new TodoEntity
        {
            Id = todo.Id,
            Name = todo.Name,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted
        });

        _context.SaveChanges();

        return Task.FromResult(true);
    }

}
