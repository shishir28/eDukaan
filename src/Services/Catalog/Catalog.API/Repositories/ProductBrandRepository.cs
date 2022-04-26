
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly ICatalogContext _context;
        public ProductBrandRepository(ICatalogContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<CatalogBrand>> GetProductBrands() =>
             await _context.CatalogBrands.Find(x => true).ToListAsync();

    }
}