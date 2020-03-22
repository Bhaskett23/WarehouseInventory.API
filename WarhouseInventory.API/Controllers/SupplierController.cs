using AutoMapper;
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
    [Route("api/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly IWarehouseInventoryRepository _warehouseInventoryRepository;
        private readonly IMapper _mapper;

        public SupplierController(IMapper mapper, IWarehouseInventoryRepository warehouseInventoryRepository)
        {
            _mapper = mapper;
            _warehouseInventoryRepository = warehouseInventoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierForViewing>> GetSuppliers()
        {
            IEnumerable<Supplier> suppliers = _warehouseInventoryRepository.GetSuppliers();

            IEnumerable<SupplierForViewing> result = _mapper.Map<IEnumerable<SupplierForViewing>>(suppliers);

            return Ok(_mapper.Map<IEnumerable<SupplierForViewing>>(suppliers));
        }

        [HttpGet("{id}", Name = "GetSupplier")]
        public ActionResult<IEnumerable<SupplierForViewing>> GetSupplier(Guid id)
        {
            Supplier suppliers = _warehouseInventoryRepository.GetSupplier(id);

            if (suppliers == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierForViewing>(suppliers));
        }

        [HttpPost]
        public ActionResult<SupplierForViewing> CreateSupplier(SupplierForCreation supplier)
        {
            Supplier newSupplier = _mapper.Map<Supplier>(supplier);

            _warehouseInventoryRepository.AddSupplier(newSupplier);
            _warehouseInventoryRepository.Save();

            SupplierForViewing supplierForViewing = _mapper.Map<SupplierForViewing>(newSupplier);

            return CreatedAtRoute("GetSupplier", new { id = supplierForViewing.Id }, supplierForViewing);
        }

        [HttpOptions]
        public IActionResult GetSupplierOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE");
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<SupplierForViewing> UpdateSupplier(Guid id, SupplierForUpdate supplierForUpdate)
        {
            Supplier supplier = _warehouseInventoryRepository.GetSupplier(id);

            if(supplier == null)
            {
                return NotFound();
            }

            _mapper.Map(supplierForUpdate, supplier);

            _warehouseInventoryRepository.UpdateSupplier(supplier);
            _warehouseInventoryRepository.Save();

            return NoContent();
        }

    }
}
