namespace BloggingPlatformAssignment.Models;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public Guid UserId { get; set; } //Author / OP
    public Guid BlogId { get; set; }
}