using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.API.Migrations
{
    public partial class _250520174 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Entries");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
