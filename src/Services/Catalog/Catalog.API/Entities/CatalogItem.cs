using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string SKU { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageFileName { get; set; }
        public string ImageUri { get; set; }
        public string Summary { get; set; }
        public string CategoryCode { get; set; }
        public string BrandCode { get; set; }
        public string DiscountCode { get; set; }
    }

}
