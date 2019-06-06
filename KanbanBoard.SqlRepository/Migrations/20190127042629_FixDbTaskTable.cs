using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class FixDbTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectTask_PriorityID",
                table: "tblProjectTask",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectTask_StageID",
                table: "tblProjectTask",
                column: "StageID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriorityID",
                table: "tblProjectTask",
                column: "PriorityID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriorityID",
                table: "tblProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblProjectStage_StageID",
                table: "tblProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_tblProjectTask_PriorityID",
                table: "tblProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_tblProjectTask_StageID",
                table: "tblProjectTask");

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
    }
}
