using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingApp.Entities;

public class User
{
  [BsonId]
  public ObjectId Id { get; set; }
  [BsonElement("username")]
  public required string Username { get; set; }
  [BsonElement("email")]
  public required string Email { get; set; }
  [BsonElement("passwordHash")]
  public required string PasswordHash { get; set; }
}