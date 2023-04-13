using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oishi.Data.Migrations
{
    public partial class AdvertisementStatusEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AdvertisementStatuses_AdvertisementStatusId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "AdvertisementStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AdvertisementStatusId",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "AdvertisementStatusId",
                table: "Advertisements",
                newName: "AdvertisementStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdvertisementStatus",
                table: "Advertisements",
                newName: "AdvertisementStatusId");

            migrationBuilder.CreateTable(
                name: "AdvertisementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertisementStatusId",
                table: "Advertisements",
                column: "AdvertisementStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AdvertisementStatuses_AdvertisementStatusId",
                table: "Advertisements",
                column: "AdvertisementStatusId",
                principalTable: "AdvertisementStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
