using Catalog.Entities;

namespace Catalog.Repositories
{

    public interface IItemsRepository
    {
        //[C]reate
        void CreateItem(Item item);


        //[R]ead
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        //[U]pdate
        void UpdateItem(Item item);


        //[D]elete
        void DeleteItem(Guid id);

        
    }
}