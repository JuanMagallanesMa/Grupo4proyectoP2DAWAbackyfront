using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class nuevamigracionPromociones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha_fin",
                table: "Promotions",
                newName: "FechaFin");

            migrationBuilder.RenameColumn(
                name: "Descuento_porcentaje",
                table: "Promotions",
                newName: "DescuentoPorcentaje");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Promotions",
                newName: "Fecha_fin");

            migrationBuilder.RenameColumn(
                name: "DescuentoPorcentaje",
                table: "Promotions",
                newName: "Descuento_porcentaje");
        }
    }
}
