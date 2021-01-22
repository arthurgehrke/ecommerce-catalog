using System.ComponentModel.DataAnnotations;

namespace EcommerceCatalog.Dtos
{
    public record CreateProductDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }   
}
