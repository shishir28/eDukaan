
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<CatalogItem>> GetProducts() =>
             await _context.CatalogItems.Find(x => true).ToListAsync();

        public async Task<CatalogItem> GetProductById(string id) =>
             await _context.CatalogItems.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<CatalogItem>> GetProductsByName(string name) =>
             await _context.CatalogItems.Find(x => x.Name == name).ToListAsync();

        public async Task<IEnumerable<CatalogItem>> GetProductsByCategory(string category) =>
              await _context.CatalogItems.Find(x => true).ToListAsync();
        //  await _context.CatalogItems.Find(x => x.Category == category).ToListAsync();

        public async Task Create(CatalogItem product) =>
            await _context.CatalogItems.InsertOneAsync(product);

        public async Task<bool> Update(CatalogItem product)
        {
            var updateResult = await _context.CatalogItems.ReplaceOneAsync(x => x.Id == product.Id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _context.CatalogItems.DeleteOneAsync(x => x.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}