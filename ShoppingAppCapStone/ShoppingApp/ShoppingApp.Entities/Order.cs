namespace ShoppingApp.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

public class Order
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }

  [BsonElement("userId")]
  public string UserId { get; set; } = null!;

  [BsonElement("orderDate")]
  public DateTime OrderDate { get; set; } = DateTime.UtcNow;

  [BsonElement("items")]
  public List<OrderItem> Items { get; set; } = new List<OrderItem>();

  [BsonElement("totalAmount")]
  public decimal TotalAmount { get; set; }
}