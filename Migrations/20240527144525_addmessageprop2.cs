using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackistwo.Migrations
{
    /// <inheritdoc />
    public partial class addmessageprop2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientName",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientName",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Message");
        }
    }
}
