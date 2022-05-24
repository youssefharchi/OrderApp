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

            return Ok(items);
        }

        // get customers that ordered an item

        [HttpGet("/GetCustomersByItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomersByItem(int ItemId)
        {
            //var customers = _itemRepository.GetCustomersByItem(ItemId);
            var customers = _mapper.Map<List<CustomerDto>>(_itemRepository.GetCustomersByItem(ItemId));

            return Ok(customers);
        }

        //get item by id

        [HttpGet("/GetItemBy/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(Item))]
        public IActionResult GetItem(int ItemId)
        {
            //var item = _itemRepository.GetItem(ItemId);
            var item = _mapper.Map<ItemDto>(_itemRepository.GetItem(ItemId));

            return Ok(item);
        }

        //get order that include the item whith the given id

        [HttpGet("/GetOrdersIncludingItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Order>))]
        public IActionResult GetOrdersByItem(int ItemId)
        {
            //var orders = _itemRepository.GetOrderByItem(ItemId);
            var orders = _mapper.Map<List<Model.Order>>(_itemRepository.GetOrderByItem(ItemId));

            return Ok(orders);
        }

        //check if item exits

        [HttpGet("/CheckItem/{ItemId}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult CheckItem(int ItemId)
        {
            var check = _itemRepository.ItemExists(ItemId);

            return Ok(check);
        }

        //post item
        [HttpPost("/postItem")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Createitem([FromBody] ItemDto itemcreate)
        {
            if (itemcreate == null)
                return BadRequest(ModelState);

            var item = _itemRepository.GetItems()
                .Where(i => i.ItemName.Trim().ToUpper() == itemcreate.ItemName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (item != null)
            {
                ModelState.AddModelError("", "Item alrady exists");
                return StatusCode(422, ModelState);
            }

            var itemMap = _mapper.Map<Item>(itemcreate);
            if (!_itemRepository.CreateItem(itemMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving ");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        // put item
        [HttpPut("/PutItem/{ItemId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer([FromQuery] int ItemId, [FromBody] ItemDto updetedItem)
        {
            if (updetedItem == null)
                return BadRequest(ModelState);

            if (ItemId != updetedItem.ItemId)
                return BadRequest(ModelState);
            if (!_itemRepository.ItemExists(ItemId))
                return NotFound();

            var ItemMap = _mapper.Map<Item>(updetedItem);
            if (!_itemRepository.UpdateItem(ItemMap))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("/DeleteItem/{ItemId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteItem(int ItemId)
        {
            if (!_itemRepository.ItemExists(ItemId))
                return NotFound();
            var ItemToDelete = _itemRepository.GetItem(ItemId);

            if (!_itemRepository.DeleteItem(ItemToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting customer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}