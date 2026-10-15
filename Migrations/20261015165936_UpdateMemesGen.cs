using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace memes_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMemesGen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gen",
                table: "Memes",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gen",
                table: "Memes");
        }
    }
}
