using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class _348975 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { 0, new DateTime(2022, 4, 23, 22, 36, 11, 857, DateTimeKind.Local).AddTicks(7601) });

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Album",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { null, new DateTime(2022, 4, 23, 19, 49, 45, 983, DateTimeKind.Local).AddTicks(6714) });

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Author_AuthorId",
                table: "Album",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
