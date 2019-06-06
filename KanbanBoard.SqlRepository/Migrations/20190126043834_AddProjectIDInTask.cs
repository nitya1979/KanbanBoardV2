using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class AddProjectIDInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "tblProjectTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectTask_ProjectID",
                table: "tblProjectTask",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProjectTask_tblProject_ProjectID",
                table: "tblProjectTask",
                column: "ProjectID",
                principalTable: "tblProject",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblProject_ProjectID",
                table: "tblProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_tblProjectTask_ProjectID",
                table: "tblProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "tblProjectTask");
        }
    }
}
