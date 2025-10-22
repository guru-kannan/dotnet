using MongoDB.Driver;
using ShoppingApp.Entities;

namespace ShoppingApp.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(MongoDbContext context)
    {
        _usersCollection = context.Users;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _usersCollection.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        var objectId = new MongoDB.Bson.ObjectId(id);
        return await _usersCollection.Find(user => user.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User entity)
    {
        await _usersCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, User entity)
    {
        var objectId = new MongoDB.Bson.ObjectId(id);
        await _usersCollection.ReplaceOneAsync(user => user.Id == objectId, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = new MongoDB.Bson.ObjectId(id);
        await _usersCollection.DeleteOneAsync(user => user.Id == objectId);
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await _usersCollection.Find(user => user.Username == username).FirstOrDefaultAsync();
    }
}