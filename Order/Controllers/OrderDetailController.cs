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

        //get order detail by id

        [HttpGet("/GetDetail/{DetailId}")]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        public IActionResult GetDetail(int DetailId)
        {
            //var detail = _orderDetailRepository.GetOrderDetail(DetailId);
            var detail = _mapper.Map<OrderDetailDto>(_orderDetailRepository.GetOrderDetail(DetailId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(detail);
        }

        //check if order detail exits

        [HttpGet("/CheckDetail/{DetailId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckDetail(int DetailId)
        {
            var check = _orderDetailRepository.OrderExists(DetailId);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }
    }
}