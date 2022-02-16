namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentCategoryCode { get; set; }
        public string ChildCategoryCode { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string SmallImageURL { get; set; }
        public string MediumImageURL { get; set; }
        public string LargeImageURL { get; set; }
        public decimal Price { get; set; }
    }
}
