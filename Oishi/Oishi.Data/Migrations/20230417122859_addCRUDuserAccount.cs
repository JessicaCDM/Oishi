using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oishi.Data.Migrations
{
    public partial class addCRUDuserAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailValidationStatus",
                table: "UserAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailValidationStatus",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
