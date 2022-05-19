using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Model.Order> GetOrders();

        ICollection<OrderDetail> GetOrderDetails(int id);

        Model.Order GetOrder(int id);

        bool OrderExists(int id);

        ICollection<Item> GetItemByOrder(int OrderId);
    }
}