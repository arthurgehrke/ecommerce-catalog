using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog.Repositories
{
    public class InMemProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product { Id = Guid.NewGuid(), Name = "product_1", Price = 10, CreatedAt = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "product_2", Price = 20, CreatedAt = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "product_3", Price = 30, CreatedAt = DateTimeOffset.UtcNow }
        };
        
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(products);
        }       

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = products.Where(product => product.Id == id).SingleOrDefault(); 
            return await Task.FromResult(product);
        }

        public async Task CreateProductAsync(Product product)
        {
            products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var index = products.FindIndex(existingProduct => existingProduct.Id == product.Id);
            products[index] = product;
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var index = products.FindIndex(existingProduct => existingProduct.Id == id);
            products.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
