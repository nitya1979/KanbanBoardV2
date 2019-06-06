using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class AddProjectIDInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriortyID",
                table: "tblProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblProjectStage_StageID",
                table: "tblProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_tblProjectTask_StageID",
                table: "tblProjectTask");

            migrationBuilder.RenameColumn(
                name: "PriortyID",
                table: "tblProjectTask",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_tblProjectTask_PriortyID",
                table: "tblProjectTask",
                newName: "IX_tblProjectTask_ProjectID");

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

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "tblProjectTask",
                newName: "PriortyID");

            migrationBuilder.RenameIndex(
                name: "IX_tblProjectTask_ProjectID",
                table: "tblProjectTask",
                newName: "IX_tblProjectTask_PriortyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectTask_StageID",
                table: "tblProjectTask",
                column: "StageID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriortyID",
                table: "tblProjectTask",
                column: "PriortyID",
                principalTable: "tblPriority",
                principalColumn: "PriorityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProjectTask_tblProjectStage_StageID",
                table: "tblProjectTask",
                column: "StageID",
                principalTable: "tblProjectStage",
                principalColumn: "StageID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
