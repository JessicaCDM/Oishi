using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oishi.Data.Migrations
{
    public partial class addMessageAndFavoriteDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_Advertisements_AdvertisementId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_HighlightTypes_HighLightTypeId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_MunicipalityOrCities_MunicipalityOrCityId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Subcategories_SubcategoryId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_UserAccounts_UserAccountId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_MunicipalityOrCities_Regions_RegionId",
                table: "MunicipalityOrCities");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Profiles_ProfileId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExternalLogins_ExternalProviders_ExternalProviderId",
                table: "UserExternalLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExternalLogins_UserAccounts_UserAccountId",
                table: "UserExternalLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInternalLogins_UserAccounts_UserAccountId",
                table: "UserInternalLogins");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    UserAccountId = table.Column<int>(type: "int", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.UserAccountId, x.AdvertisementId });
                    table.ForeignKey(
                        name: "FK_Favorites_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    SenderUserAccountId = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserAccountId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_UserAccounts_ReceiverUserAccountId",
                        column: x => x.ReceiverUserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_UserAccounts_SenderUserAccountId",
                        column: x => x.SenderUserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AdvertisementId",
                table: "Favorites",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AdvertisementId",
                table: "Messages",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverUserAccountId",
                table: "Messages",
                column: "ReceiverUserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserAccountId",
                table: "Messages",
                column: "SenderUserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHighlights_Advertisements_AdvertisementId",
                table: "AdvertisementHighlights",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementHighlights_HighlightTypes_HighLightTypeId",
                table: "AdvertisementHighlights",
                column: "HighLightTypeId",
                principalTable: "HighlightTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_MunicipalityOrCities_MunicipalityOrCityId",
                table: "Advertisements",
                column: "MunicipalityOrCityId",
                principalTable: "MunicipalityOrCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Subcategories_SubcategoryId",
                table: "Advertisements",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_UserAccounts_UserAccountId",
                table: "Advertisements",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MunicipalityOrCities_Regions_RegionId",
                table: "MunicipalityOrCities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Profiles_ProfileId",
                table: "UserAccounts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExternalLogins_ExternalProviders_ExternalProviderId",
                table: "UserExternalLogins",
                column: "ExternalProviderId",
                principalTable: "ExternalProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExternalLogins_UserAccounts_UserAccountId",
                table: "UserExternalLogins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInternalLogins_UserAccounts_UserAccountId",
                table: "UserInternalLogins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_Advertisements_AdvertisementId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementHighlights_HighlightTypes_HighLightTypeId",
                table: "AdvertisementHighlights");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_MunicipalityOrCities_MunicipalityOrCityId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Subcategories_SubcategoryId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_UserAccounts_UserAccountId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_MunicipalityOrCities_Regions_RegionId",
                table: "MunicipalityOrCities");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Profiles_ProfileId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExternalLogins_ExternalProviders_ExternalProviderId",
                table: "UserExternalLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExternalLogins_UserAccounts_UserAccountId",
                table: "UserExternalLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInternalLogins_UserAccounts_UserAccountId",
                table: "UserInternalLogins");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Messages");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_MunicipalityOrCities_MunicipalityOrCityId",
                table: "Advertisements",
                column: "MunicipalityOrCityId",
                principalTable: "MunicipalityOrCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Subcategories_SubcategoryId",
                table: "Advertisements",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_UserAccounts_UserAccountId",
                table: "Advertisements",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MunicipalityOrCities_Regions_RegionId",
                table: "MunicipalityOrCities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_CategoryId",
                table: "Subcategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Profiles_ProfileId",
                table: "UserAccounts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExternalLogins_ExternalProviders_ExternalProviderId",
                table: "UserExternalLogins",
                column: "ExternalProviderId",
                principalTable: "ExternalProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExternalLogins_UserAccounts_UserAccountId",
                table: "UserExternalLogins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInternalLogins_UserAccounts_UserAccountId",
                table: "UserInternalLogins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
