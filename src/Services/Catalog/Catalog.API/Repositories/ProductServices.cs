using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductServices : IProductServices
    {
        private readonly CatalogContext _db;

        public ProductServices(CatalogContext db)
        {
            _db = db;
        }

        public async Task CreateProduct(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var product = await GetProduct(id);
            _db.Products.Remove(product);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _db.Products.SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _db.Products.Where(p => p.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _db.Products.Where(p => p.Name == name).ToListAsync();

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
