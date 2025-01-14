using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductoCaregory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsAviable",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CantidadVenta",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Products",
                newName: "IsAviable");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Imagen");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CantidadVenta");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
