using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogDiscount
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Code")]
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Percent { get; set; }
        public bool IsActive { get; set; }
    }


}
