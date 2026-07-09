using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationIdColumnToTreeAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LOCATIONID",
                table: "TreeAssignments",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreeAssignments_LOCATIONID",
                table: "TreeAssignments",
                column: "LOCATIONID");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeAssignments_Locations_LOCATIONID",
                table: "TreeAssignments",
                column: "LOCATIONID",
                principalTable: "Locations",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeAssignments_Locations_LOCATIONID",
                table: "TreeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_TreeAssignments_LOCATIONID",
                table: "TreeAssignments");

            migrationBuilder.DropColumn(
                name: "LOCATIONID",
                table: "TreeAssignments");
        }
    }
}
