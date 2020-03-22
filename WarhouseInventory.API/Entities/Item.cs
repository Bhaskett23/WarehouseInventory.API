using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInventory.API.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public Guid SupplierId { get; set; }

        [Required]
        public double SellingPrice { get; set; }
    }
}
