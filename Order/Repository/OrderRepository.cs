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
            throw new NotImplementedException();
        }

        public Model.Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Model.Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.OrderId).ToList();
        }

        public bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}