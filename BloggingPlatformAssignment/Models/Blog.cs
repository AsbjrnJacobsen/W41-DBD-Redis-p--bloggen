namespace BloggingPlatformAssignment.Models;

public class Blog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public Guid BlogOwner { get; set; }
    
}