using Microsoft.AspNetCore.Mvc;
using EcommerceCatalog.Repositories;
using System.Collections.Generic;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly InMemProductsRepository repository;

        public ProductsController()
        {
            repository = new InMemProductsRepository();
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = repository.GetProducts();
            return products;
        }
    }
}
