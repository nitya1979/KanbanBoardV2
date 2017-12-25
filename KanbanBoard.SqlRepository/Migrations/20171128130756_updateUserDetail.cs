using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KanbanBoard.SqlRepository.Migrations
{
    public partial class updateUserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUserDetail");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "tblUserDetail",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    AboutMe = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDetail", x => x.UserName);
                });
        }
    }
}
