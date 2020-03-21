using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseInventory.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    SellingPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "Supplier" },
                values: new object[] { new Guid("dc49bab2-9151-4ce3-a9e9-66f171b7ce01"), 20, "Comes in multiple shapes.", "Soap", 4.5, "Craig's Cleaning Factory." });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "Supplier" },
                values: new object[] { new Guid("af7156e0-1fef-45ac-8204-3b9afdc29888"), 123, "Model paint", "Citedel paint", 8.5, "Games Workshop" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "Supplier" },
                values: new object[] { new Guid("d02d36a9-edf2-429c-bc42-ef70a8a2eef5"), 402, "Collectable card game packs", "Magic the Gathering Packs", 7.4000000000000004, "Wizards of the Coast" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
