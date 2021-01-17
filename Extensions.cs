using EcommerceCatalog.Dtos;
using EcommerceCatalog.Entities;

namespace EcommerceCatalog
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CreatedAt = product.CreatedAt
            };
        }
    }
}
