using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Infrastructure.SqlServer.Migrations
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
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dimensions_Width",
                table: "Covers",
                type: "int",
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
