using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItAcademy.Database.Migrations
{
    /// <inheritdoc />
    public partial class ArticleSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });
            var id = "D4BA5FE2-839E-4C04-83B8-DD0E67698771";
            var title = "Test";
            var url = "_";
            migrationBuilder.InsertData("Sources", new[] { "Id", "Title", "BaseUrl" }, new[] { id, title, url });
            
            //migrationBuilder.Sql($"INSERT INTO Sources (Id,Title,BaseUrl) VALUES ({id},{title},{url})");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Sources");
        }
    }
}
