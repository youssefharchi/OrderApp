using OrderApp.Data;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context;

        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }

        public OrderDetail GetOrderDetail(int id)
        {
            //solve warning
            return _context.Details.FirstOrDefault(d => d.OrderDetailId == id);
        }

        public bool OrderExists(int id)
        {
            return _context.Details.Any(d => d.OrderDetailId == id);
        }
    }
}