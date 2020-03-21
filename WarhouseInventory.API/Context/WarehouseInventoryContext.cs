using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseInventory.API.Entities;
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
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Soap",
                    Description = "Comes in multiple shapes.",
                    Amount = 20,
                    Supplier = "Craig's Cleaning Factory.",
                    SellingPrice = 4.50
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Citedel paint",
                    Description = "Model paint",
                    Amount = 123,
                    Supplier = "Games Workshop",
                    SellingPrice = 8.50
                },
                new Item()
                {
                    Id = Guid.NewGuid(),
                    Name = "Magic the Gathering Packs",
                    Description = "Collectable card game packs",
                    Amount = 402,
                    Supplier = "Wizards of the Coast",
                    SellingPrice = 7.40
                });
        }
    }
}
