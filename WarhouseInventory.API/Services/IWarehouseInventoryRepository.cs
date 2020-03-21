using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Entities;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.Services
{
    public interface IWarehouseInventoryRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid itemId);
        void AddItem(Item item);
        void UpdateItem(Item item);
        bool Save();
        IEnumerable<Supplier> GetSuppliers();
    }
}
