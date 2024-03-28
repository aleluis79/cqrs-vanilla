using AutoMapper;
using cqrs_vanilla.Domain.Models;
using cqrs_vanilla.Infrastructure.Entities;

namespace cqrs_vanilla.Infrastructure.Mappers;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoEntity, Todo>();
        CreateMap<Todo, TodoEntity>();
    }
}