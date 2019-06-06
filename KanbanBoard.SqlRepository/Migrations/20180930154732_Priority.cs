using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class Priority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuadrantID",
                table: "tblProject",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblPriority",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    PriorityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriorityName = table.Column<string>(maxLength: 125, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPriority", x => x.PriorityID);
                });

            migrationBuilder.InsertData(
                table: "tblPriority",
                columns: new[] { "PriorityID", "CreateDate", "CreatedBy", "ModifiedBy", "ModifyDate", "PriorityName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", null, null, "Critical" },
                    { 2, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", null, null, "Hight" },
                    { 3, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", null, null, "Medium" },
                    { 4, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", null, null, "Low" }
                });

            migrationBuilder.InsertData(
                table: "tblQuadrant",
                columns: new[] { "QuadrantID", "CreateDate", "CreatedBy", "ModifiedBy", "ModifyDate", "QuadrantName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 30, 11, 47, 32, 421, DateTimeKind.Local), "system", null, null, "Urgent And Important" },
                    { 2, new DateTime(2018, 9, 30, 11, 47, 32, 428, DateTimeKind.Local), "system", null, null, "Urgent But Not Important" },
                    { 3, new DateTime(2018, 9, 30, 11, 47, 32, 428, DateTimeKind.Local), "system", null, null, "Not Urgent But Important" },
                    { 4, new DateTime(2018, 9, 30, 11, 47, 32, 428, DateTimeKind.Local), "system", null, null, "Not Urgent And Not Important" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProject_QuadrantID",
                table: "tblProject",
                column: "QuadrantID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProject_tblQuadrant_QuadrantID",
                table: "tblProject",
                column: "QuadrantID",
                principalTable: "tblQuadrant",
                principalColumn: "QuadrantID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProject_tblQuadrant_QuadrantID",
                table: "tblProject");

            migrationBuilder.DropTable(
                name: "tblPriority");

            migrationBuilder.DropIndex(
                name: "IX_tblProject_QuadrantID",
                table: "tblProject");

            migrationBuilder.DeleteData(
                table: "tblQuadrant",
                keyColumn: "QuadrantID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblQuadrant",
                keyColumn: "QuadrantID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblQuadrant",
                keyColumn: "QuadrantID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblQuadrant",
                keyColumn: "QuadrantID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "QuadrantID",
                table: "tblProject");
        }
    }
}
