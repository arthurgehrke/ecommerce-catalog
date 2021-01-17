using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EcommerceCatalog.Repositories;
using System.Collections.Generic;
using EcommerceCatalog.Entities;
using EcommerceCatalog.Dtos;

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
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = repository.GetProducts().Select(product => product.AsDto());

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(Guid id)
        {
            var product = repository.GetProduct(id);

            if (product is null)
            {
                return NotFound();
            }

            return product.AsDto();
        }
    }
}
