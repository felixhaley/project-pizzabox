using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class _740 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "Name",
                value: "Onion");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<long>(
                name: "SizeEntityId",
                table: "Pizzas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 5L,
                column: "Name",
                value: "Onions");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
