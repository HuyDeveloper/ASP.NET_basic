using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class InitWebDB_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "shoe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "cart",
                column: "id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "shoe",
                columns: new[] { "id", "CartId", "brand", "description", "name", "price" },
                values: new object[,]
                {
                    { 1, 1, "Nike", "Nike Air Force 1", "Nike Air Force 1", 100m },
                    { 2, 1, "Nike", "Nike Air Force 2", "Nike Air Force 2", 200m },
                    { 3, 2, "Nike", "Nike Air Force 3", "Nike Air Force 3", 300m },
                    { 4, 2, "Nike", "Nike Air Force 4", "Nike Air Force 4", 400m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoe_CartId",
                table: "shoe",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoe_cart_CartId",
                table: "shoe",
                column: "CartId",
                principalTable: "cart",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoe_cart_CartId",
                table: "shoe");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropIndex(
                name: "IX_shoe_CartId",
                table: "shoe");

            migrationBuilder.DeleteData(
                table: "shoe",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "shoe",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "shoe",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "shoe",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "shoe");
        }
    }
}
