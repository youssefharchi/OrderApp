using Microsoft.AspNetCore.Mvc;
using OrderApp.Interfaces;
using OrderApp.Model;

namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        //get all items

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Item>))]
        public IActionResult GetItems()
        {
            var items = _itemRepository.GetItems();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(items);
        }

        // get customers that ordered an item

        [HttpGet("/GetCustomersByItem")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomersByItem(int ItemId)
        {
            var customers = _itemRepository.GetCustomersByItem(ItemId);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(customers);
        }

        //get item by id

        [HttpGet("/getItemById")]
        [ProducesResponseType(200, Type = typeof(Item))]
        public IActionResult GetItem(int id)
        {
            var item = _itemRepository.GetItem(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(item);
        }

        //get order that include the item whith the given id

        [HttpGet("/GetOrdersIncludingItem")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrdersByItem(int id)
        {
            var orders = _itemRepository.GetOrderByItem(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(orders);
        }

        //check if item exits

        [HttpGet("/CheckItem")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckItem(int id)
        {
            var check = _itemRepository.ItemExists(id);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(check);
        }
    }
}