using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Context;
using WarehouseInventory.API.Entities;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.Services
{
    public class WarehouseInventoryRepository : IWarehouseInventoryRepository, IDisposable
    {
        private readonly WarehouseInventoryContext _context;

        public WarehouseInventoryRepository(WarehouseInventoryContext context)
        {
            _context = context;
            //_context = new WarehouseInventoryContext();
        }

        public Item GetItem(Guid itemId)
        {
            return _context.Items.FirstOrDefault(x => x.Id == itemId);
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items;
        }

        public void AddItem(Item item)
        {
            item.Id = Guid.NewGuid();
            _context.Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            
        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(true);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
