using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; init; }
    }
}
