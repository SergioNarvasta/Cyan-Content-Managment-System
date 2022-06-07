using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro6.Data.Migrations
{
    public partial class MigrationOrdenCompraImp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenCompraImp",
                columns: table => new
                {
                    IdOrdenCompraImp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOCompra = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NroOCompra = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCambio = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CodInterno = table.Column<int>(type: "int", nullable: false),
                    CodCotizacion = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    TipoCompra = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CondicionPago = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraImp", x => x.IdOrdenCompraImp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenCompraImp");
        }
    }
}
