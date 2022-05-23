using OrderApp.Data;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Item> GetItemByOrder(int OrderId)
        {
            //better ways to implement this
            var items = from item in _context.Items
                        join detail in _context.Details on item.ItemId equals detail.ItemId
                        join order in _context.Orders on detail.OrderId equals order.OrderId
                        where order.OrderId == OrderId
                        select item;
            return items.ToList();
        }

        public ICollection<OrderDetail> GetOrderDetails(int OrderId)
        {
            var details = from detail in _context.Details
                          join order in _context.Orders on detail.OrderId equals order.OrderId
                          where order.OrderId == OrderId
                          select detail;
            return details.ToList();
        }

        public Model.Order GetOrder(int id)
        {
            //solve this
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public ICollection<Model.Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.OrderId).ToList();
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.OrderId == id);
        }

        public bool CreateOrder(int CustomerId, Model.Order order)
        {
            //add customer to order
            order.CustomerId = CustomerId;
            _context.Add(order);
            return Save();
        }

        public bool Save()
        {
            var seved = _context.SaveChanges();
            return seved > 0;
        }

        public bool UpdateOrder(int CustomerId, Model.Order order)
        {
            order.CustomerId =CustomerId;
            _context.Update(order);
            return Save();
        }
    }
}