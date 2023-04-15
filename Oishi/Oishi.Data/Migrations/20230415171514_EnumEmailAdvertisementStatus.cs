using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oishi.Data.Migrations
{
    public partial class EnumEmailAdvertisementStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_EmailValidationStatuses_EmailValidationStatusId",
                table: "UserAccounts");

            migrationBuilder.DropTable(
                name: "EmailValidationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_EmailValidationStatusId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "EmailValidationStatusId",
                table: "UserAccounts",
                newName: "EmailValidationStatus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Advertisements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailValidationStatus",
                table: "UserAccounts",
                newName: "EmailValidationStatusId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Advertisements",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmailValidationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailValidationStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_EmailValidationStatusId",
                table: "UserAccounts",
                column: "EmailValidationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_EmailValidationStatuses_EmailValidationStatusId",
                table: "UserAccounts",
                column: "EmailValidationStatusId",
                principalTable: "EmailValidationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
