using System;
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
        private readonly IProductsRepository repository;

        public ProductsController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = repository.GetProducts();
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(Guid id)
        {
            var product = repository.GetProduct(id);

            if (product is null){
                return NotFound();
            }

            return product;
        }
    }
}
