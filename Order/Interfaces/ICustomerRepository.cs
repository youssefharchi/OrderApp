using OrderApp.Model;

namespace OrderApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
    }
}