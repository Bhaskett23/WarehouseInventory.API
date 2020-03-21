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

            Supplier s = suppliers.First(x => x.Id == Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            Item e = s.Items.FirstOrDefault();

            IEnumerable<SupplierForViewing> result = _mapper.Map<IEnumerable<SupplierForViewing>>(suppliers);


            return Ok(_mapper.Map<IEnumerable<SupplierForViewing>>(suppliers));
        }
    }
}
