namespace OrderApp.Interfaces
{
    public interface IOrderRepository
    {
        public ICollection<Model.Order> GetOrders();
    }
}