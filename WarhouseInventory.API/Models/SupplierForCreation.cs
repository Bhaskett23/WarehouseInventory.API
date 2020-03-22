using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseInventory.API.Models
{
    public class SupplierForCreation
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
