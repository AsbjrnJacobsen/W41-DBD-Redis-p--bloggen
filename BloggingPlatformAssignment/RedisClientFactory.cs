namespace BloggingPlatformAssignment;

public static class RedisClientFactory
{
    public static RedisClient GetRedisClient()
    {
        RedisClient redisClient = new RedisClient("127.0.0.1", 6379, "");
        redisClient.Connect();
        return redisClient;
    }
}