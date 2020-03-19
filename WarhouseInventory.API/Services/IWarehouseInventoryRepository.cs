using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.Services
{
    public interface IWarehouseInventoryRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(int itemId);
    }
}
