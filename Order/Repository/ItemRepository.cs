using OrderApp.Data;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetCustomerByOrder(int ItemId)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.OrderBy(i => i.ItemId).ToList();
        }

        public ICollection<Model.Order> GetOrderByItem(int ItemId)
        {
            throw new NotImplementedException();
        }

        public bool ItemExists(int Id)
        {
            throw new NotImplementedException();
        }
    }
}