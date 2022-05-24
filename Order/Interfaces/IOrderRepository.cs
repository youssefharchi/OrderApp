using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Model.Order> GetOrders();

        ICollection<OrderDetail> GetOrderDetails(int id);

        Model.Order GetOrder(int id);

        bool OrderExists(int id);

        bool CreateOrder(int CustomerId, Model.Order order);

        bool UpdateOrder(int CustomerId, Model.Order order);

        bool DeleteOrder(Model.Order Order);

        bool Save();

        ICollection<Item> GetItemByOrder(int OrderId);
    }
}