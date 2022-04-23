using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicPlayer.Migrations
{
    public partial class _123412 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 23, 19, 49, 45, 983, DateTimeKind.Local).AddTicks(6714));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 23, 17, 40, 27, 724, DateTimeKind.Local).AddTicks(7977));
        }
    }
}
