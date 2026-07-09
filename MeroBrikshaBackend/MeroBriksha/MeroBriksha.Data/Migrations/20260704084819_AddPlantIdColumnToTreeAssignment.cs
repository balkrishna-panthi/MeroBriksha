using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlantIdColumnToTreeAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PLANTID",
                table: "TreeAssignments",
                type: "nvarchar(50)",
                nullable: true,
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
                onDelete: ReferentialAction.Restrict);
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
        }
    }
}
