using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class commentedrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeEntityId1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "SizeEntityId1",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SizeEntityId1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeEntityId1",
                table: "Pizzas",
                column: "SizeEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeEntityId1",
                table: "Pizzas",
                column: "SizeEntityId1",
                principalTable: "Sizes",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
