using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
        Item GetItem(int id);
        ICollection<Model.Order> GetOrderByItem(int ItemId);
        ICollection<Customer> GetCustomerByOrder(int ItemId);
        bool ItemExists(int Id);
    }
}