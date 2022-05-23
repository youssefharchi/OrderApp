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

        public ICollection<Customer> GetCustomersByItem(int ItemId)
        {
            //look for better ways to get the customers
            var customers = from customer in _context.Customers
                            join order in _context.Orders on customer.CustomerId equals order.CustomerId
                            join detail in _context.Details on order.OrderId equals detail.OrderId
                            where detail.ItemId == ItemId
                            select customer;
            return customers.ToList();
        }

        public Item GetItem(int id)
        {
            //look to solve the warning
            return _context.Items.FirstOrDefault(i => i.ItemId == id);
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.OrderBy(i => i.ItemId).ToList();
        }

        public ICollection<Model.Order> GetOrderByItem(int ItemId)
        {
            //again need better ways to replace this
            var orders = from order in _context.Orders
                         join detail in _context.Details on order.OrderId equals detail.OrderId
                         where detail.ItemId == ItemId
                         select order;
            return orders.ToList();
        }

        public bool ItemExists(int Id)
        {
            return _context.Items.Any(i => i.ItemId == Id);
        }

        public bool CreateItem(Item item)
        {
            _context.Add(item);
            return Save();
        }
        public bool UpdateItem(Item item)
        {
            _context.Update(item);
            return Save();
        }

        public bool Save()
        {
            var seved = _context.SaveChanges();
            return seved > 0;
        }
    }
}