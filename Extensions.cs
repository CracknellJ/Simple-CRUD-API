using Catalog.DTOs;
using Catalog.Entities;

namespace Catalog
{
    //extensions need to be static as no instance created
    public static class Extensions
    {
        public static ItemDTO AsDto(this Item item)
        {
            return new ItemDTO 
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreationDate = item.CreationDate
            };
        }

    }
}
