using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogBrand
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Code")]
        public string Code { get; set; }
        public string Name { get; set; }
    }


}
