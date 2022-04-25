using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class _93755 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 25, 7, 58, 24, 25, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 25, 7, 58, 24, 26, DateTimeKind.Local).AddTicks(9400));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 25, 7, 55, 49, 535, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 25, 7, 55, 49, 536, DateTimeKind.Local).AddTicks(5092));
        }
    }
}
