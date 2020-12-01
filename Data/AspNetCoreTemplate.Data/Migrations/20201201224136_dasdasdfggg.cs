namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class dasdasdfggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Trainings_TrainingId",
                table: "Reports");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Trainings_TrainingId",
                table: "Reports",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Trainings_TrainingId",
                table: "Reports");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Trainings_TrainingId",
                table: "Reports",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
