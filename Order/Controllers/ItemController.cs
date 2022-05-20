using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApp.Dto;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        //get all items

        [HttpGet("/GetItems")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public IActionResult GetItems()
        {
            //var items = _itemRepository.GetItems();
            var items = _mapper.Map<List<ItemDto>>(_itemRepository.GetItems());
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(items);
        }

        // get customers that ordered an item

        [HttpGet("/GetCustomersByItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomersByItem(int ItemId)
        {
            //var customers = _itemRepository.GetCustomersByItem(ItemId);
            var customers = _mapper.Map<List<CustomerDto>>(_itemRepository.GetCustomersByItem(ItemId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customers);
        }

        //get item by id

        [HttpGet("/GetItemBy/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(Item))]
        public IActionResult GetItem(int ItemId)
        {
            //var item = _itemRepository.GetItem(ItemId);
            var item = _mapper.Map<ItemDto>(_itemRepository.GetItem(ItemId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(item);
        }

        //get order that include the item whith the given id

        [HttpGet("/GetOrdersIncludingItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrdersByItem(int ItemId)
        {
            //var orders = _itemRepository.GetOrderByItem(ItemId);
            var orders = _mapper.Map<List<Model.Order>>(_itemRepository.GetOrderByItem(ItemId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //check if item exits

        [HttpGet("/CheckItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckItem(int ItemId)
        {
            var check = _itemRepository.ItemExists(ItemId);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }
    }
}