using System;

namespace EcommerceCatalog.Entities
{
    public record Products
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedAt { get; init; } 

    }
}

