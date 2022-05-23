using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();

        Customer GetCustomer(int id);

        ICollection<Model.Order> GetOrdersByCustomer(int customerId);

        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);

        bool Save();

        bool CustomerExists(int id);
    }
}