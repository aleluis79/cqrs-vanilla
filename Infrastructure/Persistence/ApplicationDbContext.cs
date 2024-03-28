using cqrs_vanilla.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vanilla.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{

    public DbSet<TodoEntity> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}