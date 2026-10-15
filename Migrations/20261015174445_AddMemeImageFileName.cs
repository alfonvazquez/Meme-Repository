using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace memes_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class AddMemeImageFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Memes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Memes");
        }
    }
}
