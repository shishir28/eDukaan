
using Catalog.API.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IWebHostEnvironment env, IConfiguration config)

        {
            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));
            var catalogItems = database.GetCollection<CatalogItem>(config.GetValue<string>("DatabaseSettings:ItemCollectionName"));
            var catalogBrands = database.GetCollection<CatalogBrand>(config.GetValue<string>("DatabaseSettings:BrandCollectionName"));
            var catalogCategories = database.GetCollection<CatalogCategory>(config.GetValue<string>("DatabaseSettings:CategoryCollectionName"));
            var catalogDiscounts = database.GetCollection<CatalogDiscount>(config.GetValue<string>("DatabaseSettings:DiscountCollectionName"));

            var existingCatalogCategories = catalogCategories.Find(p => true).ToList().Any();

            var catalogTuple = ParseCatalogData(env.ContentRootPath);


            var existingItems = catalogItems.Find(p => true).ToList().Any();

            if (!existingItems)
                catalogItems.InsertManyAsync(catalogTuple.Item3);

            if (!existingCatalogCategories)
                catalogCategories.InsertManyAsync(catalogTuple.Item1);


            var existingCatalogBrands = catalogBrands.Find(p => true).ToList().Any();

            if (!existingCatalogBrands)
                catalogBrands.InsertManyAsync(catalogTuple.Item2);


            var existingCatalogDiscounts = catalogDiscounts.Find(p => true).ToList().Any();

            if (!existingCatalogDiscounts)
                catalogDiscounts.InsertManyAsync(GetPreconfiguredCatalogDiscounts());
        
        }

        private static IEnumerable<CatalogDiscount> GetPreconfiguredCatalogDiscounts()
        {
            return new List<CatalogDiscount>()
            {
                new CatalogDiscount() {
                    Code = "seasonal",
                    Description="Season Discount",
                    Percent=20, IsActive= false},

                new CatalogDiscount() {
                    Code = "weekly",
                    Description="Weekly Discount",
                    Percent= 10, IsActive= true},
            };
        }

        private static (IEnumerable<CatalogCategory>, IEnumerable<CatalogBrand>, IEnumerable<CatalogItem>) ParseCatalogData(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "Setup", "InitialCatalogDataSetup.json");
            var cataLogItems = JsonConvert.DeserializeObject<List<CatalogItem>>(File.ReadAllText(fileName));
            var brands = cataLogItems.Select(x => x.BrandCode).Distinct();
            var brandList = brands.Select(x => new CatalogBrand() { Code = x.Replace(" ", "").ToLower(), Name = x }).ToList();
            var parentCategories = cataLogItems.Select(x => x.ParentCategoryCode).Distinct();
            var childCategories = cataLogItems.Select(x => x.ChildCategoryCode).Distinct();
            var categoryList = (parentCategories.Union(childCategories)).Select(x => new CatalogCategory
            {
                Code = x.Replace(" ", "").ToLower(),
                Name = x,
                LocaleCode = "en"
            }).ToList();

            var catalogItemList = cataLogItems.Select(x =>
            {
                x.Price = x.Price;
                x.BrandName = x.BrandCode;
                x.BrandCode = x.BrandCode.Replace(" ", "").ToLower();
                x.ParentCategoryCode = x.ParentCategoryCode.Replace(" ", "").ToLower();
                x.ChildCategoryCode = x.ChildCategoryCode.Replace(" ", "").ToLower();
                return x;
            });
            return (categoryList, brandList, catalogItemList);
        }


    }
}