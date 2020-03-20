using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Models;

namespace WarehouseInventory.API.Context
{
    public class WarehouseInventoryContext : DbContext
    {
        public WarehouseInventoryContext(DbContextOptions<WarehouseInventoryContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        //private void SetUp()
        //{
        //    Items = new List<Item>();
        //    Item medicalItem = new Item(1, "Bandages", "Different kinds of bandages", 10, "Bob's medical supplies", 3);
        //    Items.Add(medicalItem);
        //    Item beams = new Item(2, "Construction Beams", "Beams of different length", 30, "Steaves construction supplies", 200);
        //    Items.Add(beams);
        //
        //}
    }
}
