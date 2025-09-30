using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ShoppingApp.Entities
{
    public class OrderItem
    {
        [BsonElement("productId")]
        public ObjectId ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}
