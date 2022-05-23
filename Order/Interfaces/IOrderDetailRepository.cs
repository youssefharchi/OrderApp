using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderDetailRepository
    {
        OrderDetail GetOrderDetail(int id);

        ICollection<OrderDetail> GetAllDetails();

        bool CreateDetail(OrderDetail orderDetail, int itemId, int orderId);
        bool UpdateDetail(OrderDetail orderDetail, int itemId, int orderId);

        bool Save();

        bool OrderDetailExists(int id);
    }
}