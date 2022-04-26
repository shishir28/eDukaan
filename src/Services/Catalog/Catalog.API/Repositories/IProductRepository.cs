
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<CatalogItem>> GetProducts();
        Task<CatalogItem> GetProductById(string id);
        Task<IEnumerable<CatalogItem>> GetProductsByName(string name);
        Task<IEnumerable<CatalogItem>> GetProductsByCategory(string category);
        Task Create(CatalogItem product);
        Task<bool> Update(CatalogItem product);
        Task<bool> Delete(string id);
    }
}