using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class fixeddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PizzaEntityId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PizzaEntityId",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
