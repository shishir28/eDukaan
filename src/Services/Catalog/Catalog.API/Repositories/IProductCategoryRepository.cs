
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<CatalogCategory>> GetProductCategories();
    }

}