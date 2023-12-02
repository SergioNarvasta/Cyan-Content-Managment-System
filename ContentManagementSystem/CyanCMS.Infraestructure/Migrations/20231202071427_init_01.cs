using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyanCMS.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol_Estado = table.Column<int>(type: "int", nullable: false),
                    Audit_UsuCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_UsuAct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecAct = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Telefono = table.Column<int>(type: "int", nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Estado = table.Column<int>(type: "int", nullable: false),
                    Plan_Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol_Id_Fk = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: true),
                    Audit_UsuCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_UsuAct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecAct = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_User_Rol_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rol",
                        principalColumn: "Rol_Id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Telefono = table.Column<int>(type: "int", nullable: false),
                    Company_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Estado = table.Column<int>(type: "int", nullable: false),
                    Plan_Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id_Fk = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Audit_UsuCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecCre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_UsuAct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audit_FecAct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Tamanio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Company_Id);
                    table.ForeignKey(
                        name: "FK_Company_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_User_Id",
                table: "Company",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Rol_Id",
                table: "User",
                column: "Rol_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
