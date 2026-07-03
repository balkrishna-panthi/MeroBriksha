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
                name: "PLANTID",
                table: "TreeAssignments",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SPECIES",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TreeAssignments_PLANTID",
                table: "TreeAssignments",
                column: "PLANTID");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeAssignments_Plants_PLANTID",
                table: "TreeAssignments",
                column: "PLANTID",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeAssignments_Plants_PLANTID",
                table: "TreeAssignments");

            migrationBuilder.DropIndex(
                name: "IX_TreeAssignments_PLANTID",
                table: "TreeAssignments");

            migrationBuilder.DropColumn(
                name: "PLANTID",
                table: "TreeAssignments");

            migrationBuilder.DropColumn(
                name: "SPECIES",
                table: "Plants");
        }
    }
}
