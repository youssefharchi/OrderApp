using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
    }
}