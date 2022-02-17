namespace Razor.UI.Models
{
    public class CatalogModel
    {
        public string? Id { get; set; }
        public string? SKU { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? SmallImageURL { get; set; }
        public string? MediumImageURL { get; set; }
        public string? LargeImageURL { get; set; }
        public string? Summary { get; set; }
        public string? BrandCode { get; set; }
        public string? BrandName { get; set; }
        public string? ParentCategoryCode { get; set; }
        public string? ChildCategoryCode { get; set; }
        public string? DiscountCode { get; set; }
        public decimal Rating { get; set; }
    }

    public class CatalogBrandModel
    {
        public string? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }

        public int ProductCount { get; set; }
    }

    public class CatalogCategoryModel
    {
        public string? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? LocaleCode { get; set; }
        public int ProductCount { get; set; }

    }

}
