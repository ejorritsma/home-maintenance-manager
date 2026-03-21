using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assets");
        }
    }
}
