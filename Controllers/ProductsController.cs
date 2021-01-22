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

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateProductDto productDto)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            repository.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, UpdateProductDto productDto)
        {
            var existingProduct = repository.GetProduct(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            Product updatedProduct = existingProduct with 
            {
                Name = productDto.Name,
                Price = productDto.Price
            };

            repository.UpdateProduct(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id )
        {
            var existingProduct = repository.GetProduct(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            repository.DeleteProduct(id);

            return NoContent();
        }
    }
}
