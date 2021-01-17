using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }       

        public Product GetProduct(Guid id)
        {
            return products.Where(product => product.Id == id).SingleOrDefault(); 
        }
    }
}
