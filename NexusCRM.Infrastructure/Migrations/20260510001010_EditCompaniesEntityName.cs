using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusCRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditCompaniesEntityName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companys_CompanyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Companys_Slug",
                table: "Companies",
                newName: "IX_Companies_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companys");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_Slug",
                table: "Companys",
                newName: "IX_Companys_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companys_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
