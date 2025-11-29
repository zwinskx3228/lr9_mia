using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lr4_3.Models
{
    public class MenuItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("restaurant_id")]
        public int RestaurantId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}
