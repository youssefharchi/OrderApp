using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();

        Item GetItem(int id);

        ICollection<Model.Order> GetOrderByItem(int ItemId);

        ICollection<Customer> GetCustomersByItem(int ItemId);

        bool CreateItem(Item item);

        bool UpdateItem(Item item);

        bool DeleteItem(Item Item);

        bool Save();

        bool ItemExists(int Id);
    }
}