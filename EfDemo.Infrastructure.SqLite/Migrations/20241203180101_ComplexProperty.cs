using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Infrastructure.SqLite.Migrations
{
    /// <inheritdoc />
    public partial class ComplexProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dimensions_Height",
                table: "Covers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dimensions_Width",
                table: "Covers",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions_Height",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "Dimensions_Width",
                table: "Covers");
        }
    }
}
