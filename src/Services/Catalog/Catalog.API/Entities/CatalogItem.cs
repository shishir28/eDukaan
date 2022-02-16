using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public string SKU { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SmallImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string LargeImageURL { get; set; }
        public string Summary { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string ParentCategoryCode { get; set; }
        public string ChildCategoryCode { get; set; }
        public string DiscountCode { get; set; }
        public decimal Rating { get; set; }
    }

}
