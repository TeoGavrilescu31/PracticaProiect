using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaProiect.Migrations
{
    public partial class ThirdM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Categories_CategoryID",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Menus",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_CategoryID",
                table: "Menus",
                newName: "IX_Menus_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Menus",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                newName: "IX_Menus_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Categories_CategoryID",
                table: "Menus",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
