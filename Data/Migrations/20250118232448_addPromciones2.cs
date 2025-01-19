using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPromciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promociones_Categories_CategoriaId",
                table: "Promociones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promociones",
                table: "Promociones");

            migrationBuilder.DropIndex(
                name: "IX_Promociones_CategoriaId",
                table: "Promociones");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Promociones");

            migrationBuilder.RenameTable(
                name: "Promociones",
                newName: "Promotions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_Id_categoria",
                table: "Promotions",
                column: "Id_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Categories_Id_categoria",
                table: "Promotions",
                column: "Id_categoria",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Categories_Id_categoria",
                table: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_Id_categoria",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "Promociones");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Promociones",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promociones",
                table: "Promociones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_CategoriaId",
                table: "Promociones",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promociones_Categories_CategoriaId",
                table: "Promociones",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
