using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInventory.API.Models
{
    public abstract class ItemForManipulation
    {
        [Required(ErrorMessage = "A name for items in warehouse is required")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "A selling price is required.")]
        public double SellingPrice { get; set; }
    }
}
