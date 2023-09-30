using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERestaurant.Migrations
{
    /// <inheritdoc />
    public partial class FoodItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItemsTable",
                columns: table => new
                {
                    Food_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Food_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Food_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Food_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemsTable", x => x.Food_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemsTable");
        }
    }
}
