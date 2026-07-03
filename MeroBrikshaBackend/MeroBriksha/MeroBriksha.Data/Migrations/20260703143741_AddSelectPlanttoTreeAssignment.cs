using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectPlanttoTreeAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeAssignments_Plants_PLANTID",
                table: "TreeAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "PLANTID",
                table: "TreeAssignments",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "PLANTID",
                table: "TreeAssignments",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeAssignments_Plants_PLANTID",
                table: "TreeAssignments",
                column: "PLANTID",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
