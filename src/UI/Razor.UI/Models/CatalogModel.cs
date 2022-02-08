namespace Razor.UI.Models
{
    public class CatalogModel
    {
        public string Id { get; set; }
        public string SKU { get; set; }

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

    public class CatalogBrandModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CatalogCategoryModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LocaleCode { get; set; }
    } 

}
