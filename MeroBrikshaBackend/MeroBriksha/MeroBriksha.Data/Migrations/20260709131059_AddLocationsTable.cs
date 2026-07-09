using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LOCATIONLINK = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
