using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Controllers;
using System.Collections.Generic;
using Catalog.Entities;
using System.Linq;
using Catalog.DTOs;

namespace Catalog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        //dependency injection of repository instance (1)
        private readonly IItemsRepository _repository;
        public ItemsController (IItemsRepository Irepository)
        {
            this._repository = Irepository;
        }


        // GET /items
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            var items = _repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        //ActionResult allows us to return codes or object
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO CItemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = CItemDTO.Name,
                Price = CItemDTO.Price,
                CreationDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);

            return item.AsDto();
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult<ItemDTO> UpdateItem(Guid id, UpdateItemDTO UItemDTO)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = UItemDTO.Name,
                Price = UItemDTO.Price
            };

            _repository.UpdateItem(updatedItem);

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult<ItemDTO> DeleteItem(Guid id)
        {
            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}

