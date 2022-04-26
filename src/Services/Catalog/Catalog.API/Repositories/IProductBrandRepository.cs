
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductBrandRepository
    {
        Task<IEnumerable<CatalogBrand>> GetProductBrands();
    }
}