using System;

namespace WarehouseInventory.API.Models
{
    public class ItemForAdding
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public string SupplierName { get; set; }

        public Guid SupplierId { get; set; }

        public double SellingPrice { get; set; }
    }
}
