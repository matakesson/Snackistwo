using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackistwo.Migrations
{
    /// <inheritdoc />
    public partial class addreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReported",
                table: "Reply",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReportMessage",
                table: "Reply",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReported",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "ReportMessage",
                table: "Reply");
        }
    }
}
