﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TETEX.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate98 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Sections");
        }
    }
}
