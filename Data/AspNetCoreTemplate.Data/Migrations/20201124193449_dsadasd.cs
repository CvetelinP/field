using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class dsadasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promoters_Projects_ProjectId",
                table: "Promoters");

            migrationBuilder.AddForeignKey(
                name: "FK_Promoters_Projects_ProjectId",
                table: "Promoters",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promoters_Projects_ProjectId",
                table: "Promoters");

            migrationBuilder.AddForeignKey(
                name: "FK_Promoters_Projects_ProjectId",
                table: "Promoters",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
