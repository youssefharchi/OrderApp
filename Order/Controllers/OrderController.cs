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

            return Ok(orders);
        }

        //get order by id

        [HttpGet("/GetOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(Model.Order))]
        public IActionResult GetOrderById(int OrderId)
        {
            //var order = _orderRepository.GetOrder(OrderId);
            var order = _mapper.Map<OrderDto>(_orderRepository.GetOrder(OrderId));

            return Ok(order);
        }

        //get items of an order

        [HttpGet("/GetItemsInOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public IActionResult GetItemsOrder(int OrderId)
        {
            //var items = _orderRepository.GetItemByOrder(OrderId);
            var items = _mapper.Map<List<ItemDto>>(_orderRepository.GetItemByOrder(OrderId));

            return Ok(items);
        }

        //check if order exists

        [HttpGet("/CheckOrder/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckOrder(int OrderId)
        {
            var check = _orderRepository.OrderExists(OrderId);

            return Ok(check);
        }

        //get details of an order
        [HttpGet("/GetOrderDetails/{OrderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        public IActionResult GetDetails(int OrderId)
        {
            //var details = _orderRepository.GetOrderDetails(OrderId);
            var details = _mapper.Map<List<OrderDetailDto>>(_orderRepository.GetOrderDetails(OrderId));

            return Ok(details);
        }

        //post order
        [HttpPost("/PostOrder")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromQuery] int customerId, [FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            var order = _mapper.Map<Model.Order>(orderCreate);
            if (!_orderRepository.CreateOrder(customerId, order))
            {
                ModelState.AddModelError("", "somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        //put order
        [HttpPut("/PutOrder/{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult PutOrder([FromQuery] int orderId, [FromQuery] int CustomerId, OrderDto UpdatedOrder)
        {
            if (UpdatedOrder == null)
                return BadRequest(ModelState);
            if (orderId != UpdatedOrder.OrderId)
                return BadRequest(ModelState);
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();

            var orderMap = _mapper.Map<Model.Order>(UpdatedOrder);

            if (!_orderRepository.UpdateOrder(CustomerId, orderMap))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("/DeleteOrder/{OrderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrder(int OrderId)
        {
            if (!_orderRepository.OrderExists(OrderId))
                return NotFound();
            var OrderToDelete = _orderRepository.GetOrder(OrderId);

            if (!_orderRepository.DeleteOrder(OrderToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting customer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}