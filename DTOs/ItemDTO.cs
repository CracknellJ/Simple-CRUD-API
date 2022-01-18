namespace Catalog.DTOs
{
    public record ItemDTO
    {
        //init better than set for immutable
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreationDate { get; init; }

    }
}