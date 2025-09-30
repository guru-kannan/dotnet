using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingApp.Entities;

public class ShoppingCart
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("userId")]
  public string UserId { get; set; } = null!;

  [BsonElement("items")]
  public List<CartItem> Items { get; set; } = new List<CartItem>();
}

public class CartItem
{
  [BsonElement("productId")]
  public string ProductId { get; set; } = null!;

  [BsonElement("quantity")]
  public int Quantity { get; set; }
}