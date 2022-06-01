using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteTakingApp.Migrations
{
    public partial class ChangedDateToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateCreated",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
