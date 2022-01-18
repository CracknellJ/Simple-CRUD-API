namespace Catalog.Entities
{
    //record types are like classes but better for immutable objects
    public record Item
    {
        //init better than set for immutable
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreationDate { get; init; }

    }
}