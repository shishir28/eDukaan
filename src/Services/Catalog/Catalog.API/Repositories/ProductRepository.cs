
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context) =>
            _context = context ?? throw new System.ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Product>> GetProducts() =>
             await _context.Products.Find(x => true).ToListAsync();

        public async Task<Product> GetProductById(string id) =>
             await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsByName(string name) =>
             await _context.Products.Find(x => x.Name == name).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category) =>
             await _context.Products.Find(x => x.Category == category).ToListAsync();

        public async Task Create(Product product) =>
            await _context.Products.InsertOneAsync(product);

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _context.Products.DeleteOneAsync(x => x.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}