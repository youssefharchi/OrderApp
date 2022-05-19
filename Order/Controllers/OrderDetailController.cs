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

        //get order detail by id

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        public IActionResult GetDetail(int id)
        {
            var detail = _orderDetailRepository.GetOrderDetail(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(detail);
        }

        //check if order detail exits

        [HttpGet("/CheckDetail")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckDetail(int id)
        {
            var check = _orderDetailRepository.OrderExists(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }
    }
}