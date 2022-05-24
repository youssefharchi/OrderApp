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

        public bool OrderDetailExists(int id)
        {
            return _context.Details.Any(d => d.OrderDetailId == id);
        }

        public bool CreateDetail(OrderDetail orderDetail, int itemId, int orderId)
        {
            orderDetail.ItemId = itemId;
            orderDetail.OrderId = orderId;
            _context.Add(orderDetail);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }

        public ICollection<OrderDetail> GetAllDetails()
        {
            return _context.Details.ToList();
        }

        public bool UpdateDetail(OrderDetail orderDetail, int itemId, int orderId)
        {
            orderDetail.OrderId = orderId;
            orderDetail.ItemId = itemId;
            _context.Update(orderDetail);
            return Save();
        }

        public bool DeleteDetail(OrderDetail detail)
        {
            _context.Remove(detail);
            return Save();
        }
    }
}