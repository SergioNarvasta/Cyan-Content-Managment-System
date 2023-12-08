using System;
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
                name: "Configuration",
                columns: table => new
                {
                    ConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.ConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserAdress = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Company_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ComponentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentOrder = table.Column<int>(type: "int", nullable: false),
                    ComponentStyle = table.Column<int>(type: "int", nullable: false),
                    IsSlider = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.ComponentId);
                    table.ForeignKey(
                        name: "FK_Component_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentType",
                columns: table => new
                {
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentType", x => x.ComponentTypeId);
                    table.ForeignKey(
                        name: "FK_ComponentType_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FiledId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AuditCreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FiledId);
                    table.ForeignKey(
                        name: "FK_File_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_File_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "ComponentId");
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationComponentType",
                columns: table => new
                {
                    ConfigurationComponentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationComponentType", x => x.ConfigurationComponentTypeId);
                    table.ForeignKey(
                        name: "FK_ConfigurationComponentType_ComponentType_ComponentTypeId",
                        column: x => x.ComponentTypeId,
                        principalTable: "ComponentType",
                        principalColumn: "ComponentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationComponentType_Configuration_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configuration",
                        principalColumn: "ConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Component_CompanyId",
                table: "Component",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentType_ComponentId",
                table: "ComponentType",
                column: "ComponentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationComponentType_ComponentTypeId",
                table: "ConfigurationComponentType",
                column: "ComponentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationComponentType_ConfigurationId",
                table: "ConfigurationComponentType",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_File_CompanyId",
                table: "File",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_File_ComponentId",
                table: "File",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationComponentType");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "ComponentType");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
