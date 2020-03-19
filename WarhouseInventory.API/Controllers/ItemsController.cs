using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public ItemsController(IMapper mapper)
        {
            _mapper = mapper;

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

        [HttpGet("{Id}", Name = "GetItem")]
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
        public ActionResult<Item> CreateItem(ItemForCreation item)
        {
            Item newItem = _mapper.Map<Item>(item);

            _warehouseInventoryRepository.AddItem(newItem);

            return CreatedAtRoute("GetItem", new {id = newItem.Id }, newItem);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateItem(int id, ItemForCreation item)
        {
            Item itemToUpdate = _warehouseInventoryRepository.GetItem(id);
            if(itemToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(item, itemToUpdate);

            _warehouseInventoryRepository.UpdateItem(item);

            return NoContent();
        }

        [HttpPatch("{Id}")]
        public ActionResult<Item> PartiallyUpdateItem(int id, JsonPatchDocument<ItemForUpdate> patchDocument)
        {
            Item itemToUpdate = _warehouseInventoryRepository.GetItem(id);

            if(itemToUpdate == null)
            {
                return NotFound();
            }

            ItemForUpdate itemForUpdating = _mapper.Map<ItemForUpdate>(itemToUpdate);

            patchDocument.ApplyTo(itemForUpdating, ModelState);

            if(!TryValidateModel(itemForUpdating))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemForUpdating, itemToUpdate);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetItemOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,PATCH");
            return Ok();
        }
    }
}
