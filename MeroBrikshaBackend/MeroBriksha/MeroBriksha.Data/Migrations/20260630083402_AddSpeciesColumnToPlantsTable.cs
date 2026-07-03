using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeciesColumnToPlantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SPECIES",
                table: "Plants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SPECIES",
                table: "Plants");
        }
    }
}
