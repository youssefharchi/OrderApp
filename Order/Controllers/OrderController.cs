using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Dto;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //Get all orders

        [HttpGet("/GetOreders")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrders()
        {
            // var orders = _orderRepository.GetOrders();
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetOrders());
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //get order by id

        [HttpGet("/GetOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(Model.Order))]
        public IActionResult GetOrderById(int OrderId)
        {
            //var order = _orderRepository.GetOrder(OrderId);
            var order = _mapper.Map<OrderDto>(_orderRepository.GetOrder(OrderId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(order);
        }

        //get items of an order

        [HttpGet("/GetItemsInOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public IActionResult GetItemsOrder(int OrderId)
        {
            //var items = _orderRepository.GetItemByOrder(OrderId);
            var items = _mapper.Map<List<ItemDto>>(_orderRepository.GetItemByOrder(OrderId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(items);
        }

        //check if order exists

        [HttpGet("/CheckOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckOrder(int OrderId)
        {
            var check = _orderRepository.OrderExists(OrderId);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }

        //get details of an order
        [HttpGet("/GetOrderDetails/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        public IActionResult GetDetails(int OrderId)
        {
            //var details = _orderRepository.GetOrderDetails(OrderId);
            var details = _mapper.Map<List<OrderDetailDto>>(_orderRepository.GetOrderDetails(OrderId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(details);
        }
    }
}