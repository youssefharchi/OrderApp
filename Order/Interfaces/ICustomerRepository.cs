using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();

        Customer GetCustomer(int id);

        ICollection<Model.Order> GetOrdersByCustomer(int customerId);

        bool CustomerExists(int id);
    }
}