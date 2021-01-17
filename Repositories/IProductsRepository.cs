using System;
using System.Collections.Generic;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog.Repositories
{
    public interface IProductsRepository
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts();
    }
}
