using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseInventory.API.Migrations
{
    public partial class UpdateForSupplierInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("af7156e0-1fef-45ac-8204-3b9afdc29888"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d02d36a9-edf2-429c-bc42-ef70a8a2eef5"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("dc49bab2-9151-4ce3-a9e9-66f171b7ce01"));

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "123 Clean Avenue, NH", "Test@Test.com", "Mr. Clean's Factory", "123-456-7890" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "London", null, "Games Workshop", "444-444-3333" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Californa", "Resupply@WTC.com", "Wizards of the Coast", null },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "West Virgina", "BM@BuyersMarkett.com", "Buyers Markett", null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("a003a0aa-75bf-4334-b255-c477c0d827a6"), 20, "Comes in multiple shapes.", "Soap", 4.5, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("392f3c6e-77a4-4a22-8269-e8b74da0996e"), 123, "Model paint", "Citedel paint", 8.5, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("fa2f4c62-ab3c-4136-8d46-306d9f550794"), 402, "Collectable card game packs", "Magic the Gathering Packs", 7.4000000000000004, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09") });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("392f3c6e-77a4-4a22-8269-e8b74da0996e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a003a0aa-75bf-4334-b255-c477c0d827a6"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fa2f4c62-ab3c-4136-8d46-306d9f550794"));

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
