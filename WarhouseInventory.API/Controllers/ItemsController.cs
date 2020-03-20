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
        private readonly IWarehouseInventoryRepository _warehouseInventoryRepository;
        private readonly IMapper _mapper;

        public ItemsController(IMapper mapper, IWarehouseInventoryRepository warehouseInventoryRepository)
        {
            _mapper = mapper;

            _warehouseInventoryRepository = warehouseInventoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemForAdding>> GetItems()
        {
            var items = _warehouseInventoryRepository.GetItems();

            return Ok(items);
        }

        [HttpGet("{Id}", Name = "GetItem")]
        public ActionResult<ItemForAdding> GetItem(int id)
        {
            ItemForAdding item = _warehouseInventoryRepository.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ItemForAdding> CreateItem(ItemForCreation item)
        {
            ItemForAdding newItem = _mapper.Map<ItemForAdding>(item);

            _warehouseInventoryRepository.AddItem(newItem);

            return CreatedAtRoute("GetItem", new {id = newItem.Id }, newItem);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateItem(int id, ItemForCreation item)
        {
            ItemForAdding itemToUpdate = _warehouseInventoryRepository.GetItem(id);
            if(itemToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(item, itemToUpdate);

            _warehouseInventoryRepository.UpdateItem(item);

            return NoContent();
        }

        [HttpPatch("{Id}")]
        public ActionResult<ItemForAdding> PartiallyUpdateItem(int id, JsonPatchDocument<ItemForUpdate> patchDocument)
        {
            ItemForAdding itemToUpdate = _warehouseInventoryRepository.GetItem(id);

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
