using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Entities;
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
            IEnumerable<Item> items = _warehouseInventoryRepository.GetItems();

            return Ok(_mapper.Map<IEnumerable<ItemForAdding>>(items));
        }

        [HttpGet("{Id}", Name = "GetItem")]
        public ActionResult<ItemForAdding> GetItem(Guid id)
        {
            Item item = _warehouseInventoryRepository.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ItemForAdding>(item));
        }

        [HttpPost]
        public ActionResult<ItemForAdding> CreateItem(ItemForCreation item)
        {
            Item newItem = _mapper.Map<Item>(item);

            _warehouseInventoryRepository.AddItem(newItem);
            _warehouseInventoryRepository.Save();

            var itemToReturn = _mapper.Map<ItemForAdding>(newItem);

            return CreatedAtRoute("GetItem", new {id = newItem.Id }, itemToReturn);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateItem(Guid id, ItemForUpdate item)
        {
            Item itemToUpdate = _warehouseInventoryRepository.GetItem(id);
            if(itemToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(item, itemToUpdate);

            _warehouseInventoryRepository.UpdateItem(itemToUpdate);

            _warehouseInventoryRepository.Save();

            return NoContent();
        }

        [HttpPatch("{Id}")]
        public ActionResult<ItemForAdding> PartiallyUpdateItem(Guid id, JsonPatchDocument<ItemForUpdate> patchDocument)
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
            _warehouseInventoryRepository.Save();

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
