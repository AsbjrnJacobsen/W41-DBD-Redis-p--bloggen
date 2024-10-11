namespace BloggingPlatformAssignment.Models;

public class Comment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public Guid? ReplyToCommentId { get; set; }
    
}