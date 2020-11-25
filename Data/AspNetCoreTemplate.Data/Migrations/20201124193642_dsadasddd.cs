using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class dsadasddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promoters_Groups_GroupId",
                table: "Promoters");

            migrationBuilder.AddForeignKey(
                name: "FK_Promoters_Groups_GroupId",
                table: "Promoters",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promoters_Groups_GroupId",
                table: "Promoters");

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
