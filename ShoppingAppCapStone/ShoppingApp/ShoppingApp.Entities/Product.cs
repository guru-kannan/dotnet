using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingApp.Entities;

public class Product
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("title")]
  public string Title { get; set; } = null!;

  [BsonElement("description")]
  public string Description { get; set; } = null!;

  [BsonElement("price")]
  public decimal Price { get; set; }

  [BsonElement("imageUrl")]
  public string ImageUrl { get; set; } = null!;
  
  [BsonElement("Stock")]
  public int Stock { get; set; }
}