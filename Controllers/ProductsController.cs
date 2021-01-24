using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceCatalog.Repositories;
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
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = (await repository.GetProductsAsync()).Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(Guid id)
        {
            var product = await repository.GetProductAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreateProductDto productDto)
        {
            Product product = new()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await repository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProductAsync), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(Guid id, UpdateProductDto productDto)
        {
            var existingProduct = await repository.GetProductAsync(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            Product updatedProduct = existingProduct with 
            {
                Name = productDto.Name,
                Price = productDto.Price
            };

            await repository.UpdateProductAsync(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(Guid id )
        {
            var existingProduct = await repository.GetProductAsync(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            await repository.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
