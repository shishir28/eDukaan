
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<CatalogItem> CatalogItems { get; }
        IMongoCollection<CatalogBrand> CatalogBrands { get; }
        IMongoCollection<CatalogCategory> CatalogCategories { get; }
        IMongoCollection<CatalogDiscount> CatalogDiscounts { get; }
    }
}