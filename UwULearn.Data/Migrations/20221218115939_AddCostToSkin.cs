using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UwULearn.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCostToSkin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "Skin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Skin");
        }
    }
}
