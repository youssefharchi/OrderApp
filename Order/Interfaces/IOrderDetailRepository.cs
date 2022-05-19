using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderDetailRepository
    {
        OrderDetail GetOrderDetail(int id);

        bool OrderExists(int id);
    }
}