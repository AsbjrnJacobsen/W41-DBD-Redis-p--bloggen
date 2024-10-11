using BloggingPlatformAssignment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BloggingPlatformAssignment;

[ApiController]
[Route("api/[controller]")]
public class BlogController : Controller
{
    private readonly MongoDBContext _dbContext;

    public BlogController(MongoDBContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("blogs")]
    public IActionResult GetBlogs()
    {

        var result = _dbContext.Collection<Blog>().Find(_ => true).ToList();

        return Ok(result);
    }

    [HttpGet("GetPostsFromBlogId")]
    public IActionResult GetPostsFromBlogId([FromQuery] Guid blogId)
    {
        var result = _dbContext.Collection<Post>().Find(x => x.BlogId.Equals(blogId)).ToList();
        return Ok(result);
    }

    [HttpGet("GetCommentsFromPost")]
    public IActionResult GetCommentsFromPost([FromQuery] Guid postId)
    {
        var result = _dbContext.Collection<Comment>().Find(x => x.PostId.Equals(postId)).ToList();
        return Ok(result);
    }

    [HttpPut("UpdatePost")]
    public IActionResult UpdatePost([FromBody] Post post)
    {
        
        var result = _dbContext.Collection<Post>().ReplaceOne(filter => filter.Id == post.Id, post);
        return Ok(result);
    }

    [HttpPut("UpdateUsername")]
    public IActionResult UpdateUsername([FromBody] UpdateUsernameDTO updateUser)
    {
        var newUser = _dbContext.Collection<User>().Find(x => x.Id.Equals(updateUser.UserId)).First();
        newUser.Username = updateUser.Username;
        var result = _dbContext.Collection<User>().ReplaceOne(filter => filter.Id == updateUser.UserId, newUser);
        return Ok(result);
    }
}