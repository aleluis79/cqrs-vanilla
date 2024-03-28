using cqrs_vanilla.Infrastructure.Services;
using cqrs_vanilla.Infrastructure.Extensions;
using cqrs_vanilla.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using cqrs_vanilla.Domain.Ports.Out;
using cqrs_vanilla.Infrastructure.Repositories;
using cqrs_vanilla.Domain.Ports.In;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddTransient<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<ITodoRepositoryRead, TodoRepositoryRead>();
builder.Services.AddScoped<ITodoRepositoryWrite, TodoRepositoryWrite>();

//builder.Services.AddTransient<ICommandHandler<GetTodosCommand, GetTodosResponse>, GetTodos>();
builder.Services.AddCQRS();

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program)); 

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
