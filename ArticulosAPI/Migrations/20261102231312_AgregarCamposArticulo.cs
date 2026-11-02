using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticulosAPI.Migrations
{
    public partial class AgregarCamposArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Articulos",
                newName: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Articulos",
                newName: "Cantidad");
        }
    }
}
