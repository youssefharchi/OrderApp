using Microsoft.AspNetCore.Mvc;
using OrderApp.Interfaces;


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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Model.Order))]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }
    }
}