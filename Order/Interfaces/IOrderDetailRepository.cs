using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderDetailRepository
    {
        ICollection<OrderDetail> GetOrderDetail();
        OrderDetail GetOrderDetail(int id);
        bool OrderExists(int id);
    }
}