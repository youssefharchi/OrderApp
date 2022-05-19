using Microsoft.AspNetCore.Mvc;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //get all customers

        [HttpGet("/GetAllCustomers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomer()
        {
            var customers = _customerRepository.GetCustomers();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customers);
        }

        //get orders of a customer

        [HttpGet("/GetGetOrdersByCustomer")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrderByCustomer(int id)
        {
            var orders = _customerRepository.GetOrdersByCustomer(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //get  customer by id

        [HttpGet("/CustomeerById")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customer);
        }

        //chack if customer exists

        [HttpGet("/CheckCustomer")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CustomerExists(int id)
        {
            var exists = _customerRepository.CustomerExists(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(exists);
        }
    }
}