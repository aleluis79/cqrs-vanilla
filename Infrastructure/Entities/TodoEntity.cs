namespace cqrs_vanilla.Infraestructure.Entities;

public class TodoEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}
