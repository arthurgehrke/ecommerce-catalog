using System;

namespace EcommerceCatalog.Dtos
{
    public record ProductDto
    {
        public Guid Id { get; init; } 
        public string Name { get; init; } 
        public decimal Price { get; init; }
        public DateTimeOffset CreatedAt { get; init; }

    }
}
