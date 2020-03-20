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

        public DbSet<ItemForAdding> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemForAdding>().HasData(
                new ItemForAdding()
                {
                    Id = 1,
                    Name = "Soap",
                    Description = "Comes in multiple shapes.",
                    Amount = 20,
                    Supplier = "Craig's Cleaning Factory.",
                    SellingPrice = 4.50
                },
                new ItemForAdding()
                {
                    Id = 2,
                    Name = "Citedel paint",
                    Description = "Model paint",
                    Amount = 123,
                    Supplier = "Games Workshop",
                    SellingPrice = 8.50
                },
                new ItemForAdding()
                {
                    Id = 3,
                    Name = "Magic the Gathering Packs",
                    Description = "Collectable card game packs",
                    Amount = 402,
                    Supplier = "Wizards of the Coast",
                    SellingPrice = 7.40
                });
        }
    }
}
