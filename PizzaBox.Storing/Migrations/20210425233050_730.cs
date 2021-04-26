using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class _730 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "Greek's Pizzeria");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "Pizza King");

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "Name" },
                values: new object[] { 3L, "NewYorkStore", "Al's Pizza" });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "EntityId", "APizzaEntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, null, "Mozzarella", 0m },
                    { 2L, null, "Marinara", 0m },
                    { 3L, null, "Pepperoni", 0m },
                    { 4L, null, "Mushrooms", 0m },
                    { 5L, null, "Onions", 0m },
                    { 6L, null, "Sausage", 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 6L);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 1L, "Uncle John" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "Chitown Main Street");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "Big Apple");
        }
    }
}
