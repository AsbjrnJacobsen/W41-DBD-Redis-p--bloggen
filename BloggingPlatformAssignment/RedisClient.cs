using BloggingPlatformAssignment.Models;
using StackExchange.Redis;

namespace BloggingPlatformAssignment;

public class RedisClient
{
    private readonly string _hostname;
    private readonly int _port;
    private readonly string _password;

    private ConnectionMultiplexer redis;

    public RedisClient(string hostname, int port, string password)
    {
        _hostname = hostname;
        _port = port;
        _password = password;
    }

    public void Connect()
    {
        var connectionString = $"{_hostname}:{_port},password={_password}";
        redis = ConnectionMultiplexer.Connect(connectionString);
    }

    public IDatabase GetDatabase()
    {
        return redis.GetDatabase();
    }

    public void StoreString(string key, string value)
    {
        var db = GetDatabase();
        db.StringSet(key, value);
    }

    public string? GetString(string key)
    {
        var db = GetDatabase();
        return db.StringGet(new RedisKey(key));
    }

    public void RemoveString(string key)
    {
        var db = GetDatabase();
        db.KeyDelete(key);
    }
    
    public void AddCacheOfPostIds(Post post)
    {
        var db = GetDatabase();
    
        // Adds the post ID to a Redis Set (ensures uniqueness)
        db.SetAdd("CachedPostByIds", post.Id.ToString());
    }

    public void RemoveCachedPostList(Post post)
    {
        var db = GetDatabase();
    
        // Removes the post ID from the Redis Set
        db.SetRemove("CachedPostByIds", post.Id.ToString());
    }

    public IEnumerable<string> GetCachedPostIds()
    {
        var db = GetDatabase();
    
        // Retrieve all post IDs from the Redis Set (corrected to SetMembers)
        var postIds = db.SetMembers("CachedPostByIds");
    
        return postIds.Select(id => id.ToString());
    }
}