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

        public ICollection<Item> GetItems()
        {
            return _context.Items.OrderBy(i => i.ItemId).ToList();
        }
    }
}