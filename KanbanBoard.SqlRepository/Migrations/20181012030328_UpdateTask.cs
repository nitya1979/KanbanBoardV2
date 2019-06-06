using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class UpdateTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityID",
                table: "tblProjectTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriortyID",
                table: "tblProjectTask",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProjectTask_PriortyID",
                table: "tblProjectTask",
                column: "PriortyID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriortyID",
                table: "tblProjectTask",
                column: "PriortyID",
                principalTable: "tblPriority",
                principalColumn: "PriorityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProjectTask_tblPriority_PriortyID",
                table: "tblProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_tblProjectTask_PriortyID",
                table: "tblProjectTask");

            migrationBuilder.DropColumn(
                name: "PriorityID",
                table: "tblProjectTask");

            migrationBuilder.DropColumn(
                name: "PriortyID",
                table: "tblProjectTask");
        }
    }
}
