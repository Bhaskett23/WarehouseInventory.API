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
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasData(
                new Supplier()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Mr. Clean's Factory",
                    Address = "123 Clean Avenue, NH",
                    PhoneNumber = "123-456-7890",
                    Email = "Test@Test.com"
                },
                new Supplier()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Games Workshop",
                    Address = "London",
                    PhoneNumber = "444-444-3333"
                },
                new Supplier()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Wizards of the Coast",
                    Address = "Californa",
                    Email = "Resupply@WTC.com"
                },
                new Supplier()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Buyers Markett",
                    Address = "West Virgina",
                    Email = "BM@BuyersMarkett.com"
                });

            //modelBuilder.Entity<Supplier>()
            //    .HasMany(x => x.Items);

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "Soap",
                    Description = "Comes in multiple shapes.",
                    Amount = 20,
                    SupplierId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    SellingPrice = 4.50
                },
                new Item()
                {
                    Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    Name = "Citedel paint",
                    Description = "Model paint",
                    Amount = 123,
                    SupplierId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    SellingPrice = 8.50
                },
                new Item()
                {
                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    Name = "Magic the Gathering Packs",
                    Description = "Collectable card game packs",
                    Amount = 402,
                    SupplierId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    SellingPrice = 7.40
                });


        }
    }
}
