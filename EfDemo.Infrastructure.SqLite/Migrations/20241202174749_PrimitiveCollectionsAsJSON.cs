﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Infrastructure.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class PrimitiveCollectionsAsJSON : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nicknames",
                table: "Authors",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nicknames",
                table: "Authors");
        }
    }
}