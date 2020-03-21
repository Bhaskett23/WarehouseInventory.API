using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseInventory.API.Models
{
    public class SupplierForViewing
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<ItemForAdding> ItemsSupplied { get; set; }
    }
}