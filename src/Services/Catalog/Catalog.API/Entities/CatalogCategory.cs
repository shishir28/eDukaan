using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogCategory
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Code")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string LocaleCode { get; set; }
    }


}
