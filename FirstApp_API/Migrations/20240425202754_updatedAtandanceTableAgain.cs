using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApp_API.Migrations
{
    public partial class updatedAtandanceTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Groups_GroupId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_GroupId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Attendance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_GroupId",
                table: "Attendance",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Groups_GroupId",
                table: "Attendance",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
