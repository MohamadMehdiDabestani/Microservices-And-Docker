using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(string id);

        Task<IEnumerable<Product>> GetProductsByCategory(string category);
        
        Task<IEnumerable<Product>> GetProductsByName(string name);

        Task CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);
        
        Task<bool> DeleteProduct(string id);

    }
}
