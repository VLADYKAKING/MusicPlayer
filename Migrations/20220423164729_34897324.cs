using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Migrations
{
    public partial class _34897324 : Migration
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { null, new DateTime(2022, 4, 23, 22, 47, 28, 643, DateTimeKind.Local).AddTicks(7984) });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "AuthorId", "Date", "Name" },
                values: new object[] { 2, null, new DateTime(2022, 4, 23, 22, 47, 28, 644, DateTimeKind.Local).AddTicks(8610), "Композиции MGMT" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "MGMT" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Электропоп" });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "AlbumId", "AuthorId", "CoverPath", "FilePath", "GenreId", "Name" },
                values: new object[] { 2, 2, 2, "covers/lda.jpg", "music/MGMT - Little Dark Age.mp3", 2, "Little Dark Age" });

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

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
