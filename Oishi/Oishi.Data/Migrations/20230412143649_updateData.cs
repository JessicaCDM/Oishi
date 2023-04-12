using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oishi.Data.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementHighlights_AdvertisementId",
                table: "AdvertisementHighlights",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHighlights_Advertisements_AdvertisementId",
                table: "AdvertisementHighlights",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHighlights_HighlightTypes_HighLightTypeId",
                table: "AdvertisementHighlights",
                column: "HighLightTypeId",
                principalTable: "HighlightTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_Advertisements_AdvertisementId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_HighlightTypes_HighLightTypeId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementHighlights_AdvertisementId",
                table: "AdvertisementHighlights");
        }
    }
}
