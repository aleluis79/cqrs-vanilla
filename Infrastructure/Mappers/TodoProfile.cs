using AutoMapper;
using cqrs_vanilla.Domain.Models;
using cqrs_vanilla.Infraestructure.Entities;

namespace cqrs_vanilla.Infraestructure.Mappers;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoEntity, Todo>();
        CreateMap<Todo, TodoEntity>();
    }
}