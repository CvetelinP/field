using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class ceci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promoters_Groups_GroupId",
                table: "Promoters");

            migrationBuilder.DropIndex(
                name: "IX_Promoters_GroupId",
                table: "Promoters");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Promoters");

            migrationBuilder.CreateTable(
                name: "PromotersGroups",
                columns: table => new
                {
                    PromoterId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotersGroups", x => new { x.GroupId, x.PromoterId });
                    table.ForeignKey(
                        name: "FK_PromotersGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromotersGroups_Promoters_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "Promoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotersGroups_PromoterId",
                table: "PromotersGroups",
                column: "PromoterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotersGroups");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Promoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promoters_GroupId",
                table: "Promoters",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promoters_Groups_GroupId",
                table: "Promoters",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
