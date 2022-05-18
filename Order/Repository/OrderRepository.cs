using OrderApp.Data;
using OrderApp.Interfaces;

namespace OrderApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Model.Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.OrderId).ToList();
        }
    }
}