using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}
