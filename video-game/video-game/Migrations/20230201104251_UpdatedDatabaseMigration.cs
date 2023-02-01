using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Games",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Games");
        }
    }
}
