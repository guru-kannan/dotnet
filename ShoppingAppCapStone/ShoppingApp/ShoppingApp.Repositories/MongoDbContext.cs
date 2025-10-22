using MongoDB.Driver;
using ShoppingApp.Entities;
using Microsoft.Extensions.Configuration;


namespace ShoppingApp.Repositories;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
        var databaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

  public IMongoCollection<T> GetCollection<T>(string collectionName)
  {
    return _database.GetCollection<T>(collectionName);
  }
    
  public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
}