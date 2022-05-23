using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Dto;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        //get all customers

        [HttpGet("/GetAllCustomers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomer()
        {
            //var customers = _customerRepository.GetCustomers();
            var customers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customers);
        }

        //get orders of a customer

        [HttpGet("/GetGetOrdersByCustomer/{CustomerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrderByCustomer(int CustomerId)
        {
            //var orders = _customerRepository.GetOrdersByCustomer(CustomerId);
            var orders = _mapper.Map<List<OrderDto>>(_customerRepository.GetOrdersByCustomer(CustomerId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //get  customer by id

        [HttpGet("/CustomeerById/{CustomerId}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public IActionResult GetCustomer(int CustomerId)
        {
            //var customer = _customerRepository.GetCustomer(CustomerId);
            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(CustomerId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customer);
        }

        //chack if customer exists

        [HttpGet("/CheckCustomer/{CustomerId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CustomerExists(int CustomerId)
        {
            var exists = _customerRepository.CustomerExists(CustomerId);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(exists);
        }

        //post customer

        [HttpPost("/postCustomer")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerCreate)
        {
            if (customerCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(customerCreate);

            if (!_customerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        //put CUstomer

        [HttpPut("/PutCustomer/{customerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer([FromQuery]int customerId , [FromBody]CustomerDto updatedCustomer)
        {
            if (updatedCustomer == null)
                return BadRequest(ModelState);

            if(customerId != updatedCustomer.CustomerId)
                return BadRequest(ModelState);
            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(updatedCustomer);
            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}