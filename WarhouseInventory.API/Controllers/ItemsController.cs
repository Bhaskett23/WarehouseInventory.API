using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Models;
using WarehouseInventory.API.Services;

namespace WarehouseInventory.API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private static IWarehouseInventoryRepository _warehouseInventoryRepository;
        public ItemsController()
        {
            if(_warehouseInventoryRepository == null)
            {
                _warehouseInventoryRepository = new WarehouseInventoryRepository();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _warehouseInventoryRepository.GetItems();

            return Ok(items);
        }

        [HttpGet("{Id}")]
        public ActionResult<Item> GetItem(int id)
        {
            Item item = _warehouseInventoryRepository.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            _warehouseInventoryRepository.AddItem(item);

            return Ok();
        }
    }
}
