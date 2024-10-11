using System.Diagnostics;
using System.Linq.Expressions;
using BloggingPlatformAssignment.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BloggingPlatformAssignment;

public class MongoDBContext
{
    private readonly string _connectionString;
    private readonly IMongoClient _client;

    private readonly string _databaseName;
    private readonly string _collectionName;


    public MongoDBContext(string connectionString, string databaseName, string collectionName)
    {
        _databaseName = databaseName;
        _collectionName = collectionName;
        _connectionString = connectionString;
        _client = new MongoClient(_connectionString);
        
        
        
    }
    
    public IMongoCollection<T> Collection<T>()
    {
        return _client.GetDatabase(_databaseName).GetCollection<T>((typeof(T).Name));
    }
}