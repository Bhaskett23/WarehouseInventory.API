using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.Services
{
    public interface IWarehouseInventoryRepository
    {
        IEnumerable<ItemForAdding> GetItems();
        ItemForAdding GetItem(int itemId);
        void AddItem(ItemForAdding item);
        void UpdateItem(ItemForCreation item);
    }
}
