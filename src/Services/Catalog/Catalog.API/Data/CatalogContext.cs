
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<CatalogItem> CatalogItems { get; }
        public IMongoCollection<CatalogBrand> CatalogBrands { get; }
        public IMongoCollection<CatalogCategory> CatalogCategories { get; }
        public IMongoCollection<CatalogDiscount> CatalogDiscounts { get; }


        public CatalogContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));
            CatalogItems = database.GetCollection<CatalogItem>(config.GetValue<string>("DatabaseSettings:ItemCollectionName"));
            CatalogBrands = database.GetCollection<CatalogBrand>(config.GetValue<string>("DatabaseSettings:BrandCollectionName"));
            CatalogCategories = database.GetCollection<CatalogCategory>(config.GetValue<string>("DatabaseSettings:CategoryCollectionName"));
            CatalogDiscounts = database.GetCollection<CatalogDiscount>(config.GetValue<string>("DatabaseSettings:DiscountCollectionName"));
            CatalogContextSeed.SeedData(CatalogCategories, CatalogBrands, CatalogDiscounts, CatalogItems);
        }

    }
}