using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingApp.API.Models;

public class ProductModel
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; } = null!;

  [BsonElement("name")]
  public string Name { get; set; } = null!;

  [BsonElement("description")]
  public string Description { get; set; } = null!;

  [BsonElement("price")]
  public decimal Price { get; set; }

  [BsonElement("category")]
  public string Category { get; set; } = null!;

  [BsonElement("stockQuantity")]
  public int StockQuantity { get; set; }
}