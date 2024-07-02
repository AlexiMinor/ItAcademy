using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItAcademy.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlInArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "Articles");
        }
    }
}
