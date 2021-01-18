namespace EcommerceCatalog.Dtos
{
    public record CreateProductDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }   
}
