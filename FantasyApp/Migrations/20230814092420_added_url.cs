using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    /// <inheritdoc />
    public partial class added_url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleId",
                table: "Volume",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallThumbnail",
                table: "Volume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Volume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleId",
                table: "Volume");

            migrationBuilder.DropColumn(
                name: "SmallThumbnail",
                table: "Volume");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Volume");
        }
    }
}
