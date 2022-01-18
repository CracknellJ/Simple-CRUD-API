using Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Catalog.Repositories
{

    public class ItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Sword", Price = 10, CreationDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Shield", Price = 7, CreationDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bag", Price = 12, CreationDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        //[C]reate
        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        //[R]ead
        public Item GetItem(Guid id)
        {
            //return item by id, currently throws error if id not found
            return items.SingleOrDefault(item => item.Id == id);
        }

        //[U]pdate
        public void UpdateItem(Item item)
        {
            var itemIndex = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[itemIndex] = item;
        }

        //[D]elete
        public void DeleteItem(Guid id)
        {
            var itemIndex = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(itemIndex);
        }
    }
}