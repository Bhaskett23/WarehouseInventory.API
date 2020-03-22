using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseInventory.API.Migrations
{
    public partial class hardCodingIdsForItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 20, "Comes in multiple shapes.", "Soap", 4.5, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), 123, "Model paint", "Citedel paint", 8.5, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Description", "Name", "SellingPrice", "SupplierId" },
                values: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), 402, "Collectable card game packs", "Magic the Gathering Packs", 7.4000000000000004, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

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
        }
    }
}
