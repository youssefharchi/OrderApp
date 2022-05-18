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

        public ICollection<OrderDetail> GetOrderDetail()
        {
            return _context.Details.OrderBy(d => d.OrderDetailId).ToList();
        }

        public OrderDetail GetOrderDetail(int id)
        {
            throw new NotImplementedException();
        }

        public bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}