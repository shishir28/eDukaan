
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ICatalogContext _context;
        public ProductCategoryRepository(ICatalogContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<CatalogCategory>> GetProductCategories() =>
             await _context.CatalogCategories.Find(x => true).ToListAsync();

    }
}