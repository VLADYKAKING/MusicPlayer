using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class _23345345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 29, 22, 27, 19, 446, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 29, 22, 27, 19, 447, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 4, 29, 22, 3, 51, 812, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 4, 29, 22, 3, 51, 813, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
