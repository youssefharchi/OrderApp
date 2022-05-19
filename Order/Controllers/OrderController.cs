using Microsoft.AspNetCore.Mvc;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //Get all orders

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Model.Order))]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //get order by id

        [HttpGet("/GetOrder")]
        [ProducesResponseType(200, Type = typeof(Model.Order))]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRepository.GetOrder(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(order);
        }

        //get items of an order

        [HttpGet("/GetItemsInOrder")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public IActionResult GetItemsOrder(int id)
        {
            var items = _orderRepository.GetItemByOrder(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(items);
        }

        //check if order exists

        [HttpGet("/CheckOrder")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckOrder(int id)
        {
            var check = _orderRepository.OrderExists(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }

        //get details of an order
        [HttpGet("/GetOrderDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        public IActionResult GetDetails(int id)
        {
            var details = _orderRepository.GetOrderDetails(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(details);
        }
    }
}