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
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPriority");

            migrationBuilder.DropColumn(
                name: "QuadrantID",
                table: "tblProject");
        }
    }
}
