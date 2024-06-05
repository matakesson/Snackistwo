using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackistwo.Migrations
{
    /// <inheritdoc />
    public partial class AddSubCategoryDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subcategory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subcategory");
        }
    }
}
