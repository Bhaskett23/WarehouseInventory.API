using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInventory.API.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Supplier { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }
    }
}
