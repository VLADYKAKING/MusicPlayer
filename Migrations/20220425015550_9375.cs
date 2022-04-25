using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class _9375 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 23, 22, 47, 28, 643, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 23, 22, 47, 28, 644, DateTimeKind.Local).AddTicks(8610));
        }
    }
}
