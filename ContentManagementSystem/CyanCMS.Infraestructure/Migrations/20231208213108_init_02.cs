using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyanCMS.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_CompanyId",
                table: "Configuration",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_Company_CompanyId",
                table: "Configuration",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_Company_CompanyId",
                table: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_CompanyId",
                table: "Configuration");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Configuration");
        }
    }
}
