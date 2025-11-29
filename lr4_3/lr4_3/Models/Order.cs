using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lr4_3.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; }

        [BsonElement("restaurant_id")]
        public int RestaurantId { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public OrderStatus Status { get; set; }

        [BsonElement("items")]
        public List<OrderItem> Items { get; set; } = new();
    }

    public class OrderItem
    {
        [BsonElement("menu_item_id")]
        public int MenuItemId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
