using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog.Repositories
{
    public class InMemProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product { Id = Guid.NewGuid(), Name = "product_1", Price = string.Format("{0:0.##}", new Random().NextDouble() * 10), CreatedAt: DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "product_2", Price = string.Format("{0:0.##}", new Random().NextDouble() * 10), CreatedAt: DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "product_3", Price = string.Format("{0:0.##}", new Random().NextDouble() * 10), CreatedAt: DateTimeOffset.UtcNow }
        }
        
        public IEnumerable<Product> GetProducts
        {
            return products;
        }       

        public Product GetProduct(Guid id)
        {
            return products.Where(product => product.Id == id).SingleOrDefault(); 
        }
    }
}
