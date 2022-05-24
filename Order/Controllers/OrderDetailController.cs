using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Dto;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        //Get orders
        [HttpGet("/GetDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetail>))]
        public IActionResult GetOrders()
        {
            var details = _mapper.Map<List<OrderDetailDto>>(_orderDetailRepository.GetAllDetails());

            return Ok(details);
        }

        //get order detail by id

        [HttpGet("/GetDetail/{DetailId}")]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        public IActionResult GetDetail(int DetailId)
        {
            //var detail = _orderDetailRepository.GetOrderDetail(DetailId);
            var detail = _mapper.Map<OrderDetailDto>(_orderDetailRepository.GetOrderDetail(DetailId));

            return Ok(detail);
        }

        //check if order detail exits

        [HttpGet("/CheckDetail/{DetailId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckDetail(int DetailId)
        {
            var check = _orderDetailRepository.OrderDetailExists(DetailId);

            return Ok(check);
        }

        //post OrderDetail
        [HttpPost("/PostDetail")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDetail([FromQuery] int itemId, [FromQuery] int orderId, [FromBody] OrderDetailDto orderDetailCreate)
        {
            if (orderDetailCreate == null)
                return BadRequest(ModelState);

            var detailMap = _mapper.Map<OrderDetail>(orderDetailCreate);

            if (!_orderDetailRepository.CreateDetail(detailMap, itemId, orderId))
            {
                ModelState.AddModelError("", "somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        //put order detail
        [HttpPut("/PutDetail/{DetailId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer([FromQuery] int DetailId, [FromQuery] int OrderId, [FromQuery] int ItemId, [FromBody] OrderDetailDto updatedDetail)
        {
            if (updatedDetail == null)
                return BadRequest(ModelState);

            if (DetailId != updatedDetail.OrderDetailId)
                return BadRequest(ModelState);
            if (!_orderDetailRepository.OrderDetailExists(DetailId))
                return NotFound();

            var DetailMap = _mapper.Map<OrderDetail>(updatedDetail);
            if (!_orderDetailRepository.UpdateDetail(DetailMap, ItemId, OrderId))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("/DeleteOrderDetail/{OrderDetailId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrderDetail(int OrderDetailId)
        {
            if (!_orderDetailRepository.OrderDetailExists(OrderDetailId))
                return NotFound();
            var OrderDetailToDelete = _orderDetailRepository.GetOrderDetail(OrderDetailId);

            if (!_orderDetailRepository.DeleteDetail(OrderDetailToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting customer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}