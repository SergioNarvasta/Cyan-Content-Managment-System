using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyanCMS.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentType_Component_ComponentId",
                table: "ComponentType");

            migrationBuilder.DropIndex(
                name: "IX_ComponentType_ComponentId",
                table: "ComponentType");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ComponentType");

            migrationBuilder.AddColumn<int>(
                name: "ComponentTypeId",
                table: "Component",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Component_ComponentTypeId",
                table: "Component",
                column: "ComponentTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_ComponentType_ComponentTypeId",
                table: "Component",
                column: "ComponentTypeId",
                principalTable: "ComponentType",
                principalColumn: "ComponentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Component_ComponentType_ComponentTypeId",
                table: "Component");

            migrationBuilder.DropIndex(
                name: "IX_Component_ComponentTypeId",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "ComponentTypeId",
                table: "Component");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ComponentType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentType_ComponentId",
                table: "ComponentType",
                column: "ComponentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentType_Component_ComponentId",
                table: "ComponentType",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
