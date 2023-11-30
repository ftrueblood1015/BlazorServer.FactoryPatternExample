using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServer.FactoryPatternExample.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AmountOrder", "Comment", "Description", "Name", "ProductId", "ShippingCost", "StateId", "Total" },
                values: new object[] { 1, 1, "Order 1", "Order 1", "Order 1", 1, 10.0, 1, 1009.99 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AmountOrder", "Comment", "Description", "Name", "ProductId", "ShippingCost", "StateId", "Total" },
                values: new object[] { 2, 1, "Order 2", "Order 2", "Order 2", 1, 20.0, 2, 1019.99 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AmountOrder", "Comment", "Description", "Name", "ProductId", "ShippingCost", "StateId", "Total" },
                values: new object[] { 3, 1, "Order 3", "Order 3", "Order 3", 1, 50.0, 3, 1059.99 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Comment", "Cost", "Description", "Name" },
                values: new object[] { 1, "This is a Car", 999.99000000000001, "Car", "Civic" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Comment", "Cost", "Description", "Name" },
                values: new object[] { 2, "This is a Bus", 9999.9899999999998, "Bus", "Grey Hound" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Comment", "Cost", "Description", "Name" },
                values: new object[] { 3, "This is a Truck", 4999.9899999999998, "Truck", "Tacoma" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "Comment", "Description", "Name" },
                values: new object[] { 1, "CA", "California", "California", "California" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "Comment", "Description", "Name" },
                values: new object[] { 2, "AZ", "Arizona", "Arizona", "Arizona" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "Comment", "Description", "Name" },
                values: new object[] { 3, "NY", "New York", "New York", "New York" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
