using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInventory.API.Models
{
    public class ItemForCreation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public string Supplier { get; set; }

        public double SellingPrice { get; set; }
    }
}
