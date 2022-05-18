using Microsoft.AspNetCore.Mvc;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        public IActionResult GetDetails()
        {
            var details = _orderDetailRepository.GetOrderDetail();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(details);
        }
    }
}