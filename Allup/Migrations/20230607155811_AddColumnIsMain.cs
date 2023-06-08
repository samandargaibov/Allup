﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allup.Migrations
{
    public partial class AddColumnIsMain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Categories",
                type: "int",
                nullable: true);
        }
    }
}
