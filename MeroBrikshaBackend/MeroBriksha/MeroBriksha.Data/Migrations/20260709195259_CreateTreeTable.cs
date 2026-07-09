using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTreeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TREEASSIGNMENTID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PLANTID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LOCATIONLINK = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "decimal(10,7)", precision: 10, scale: 7, nullable: true),
                    PLANTEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    TRACKINGCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trees_Plants_PLANTID",
                        column: x => x.PLANTID,
                        principalTable: "Plants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trees_TreeAssignments_TREEASSIGNMENTID",
                        column: x => x.TREEASSIGNMENTID,
                        principalTable: "TreeAssignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trees_PLANTID",
                table: "Trees",
                column: "PLANTID");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_TRACKINGCODE",
                table: "Trees",
                column: "TRACKINGCODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trees_TREEASSIGNMENTID",
                table: "Trees",
                column: "TREEASSIGNMENTID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trees");
        }
    }
}
