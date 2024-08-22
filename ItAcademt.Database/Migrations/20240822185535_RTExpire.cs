using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItAcademy.Database.Migrations
{
    /// <inheritdoc />
    public partial class RTExpire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDateTime",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDateTime",
                table: "RefreshTokens");
        }
    }
}
