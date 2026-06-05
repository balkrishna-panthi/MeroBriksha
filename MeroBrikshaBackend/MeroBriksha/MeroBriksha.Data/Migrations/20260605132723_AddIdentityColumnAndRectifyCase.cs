using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityColumnAndRectifyCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScientificName",
                table: "Plants",
                newName: "SCIENTIFICNAME");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Plants",
                newName: "DESCRIPTION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SCIENTIFICNAME",
                table: "Plants",
                newName: "ScientificName");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "Plants",
                newName: "Description");
        }
    }
}
