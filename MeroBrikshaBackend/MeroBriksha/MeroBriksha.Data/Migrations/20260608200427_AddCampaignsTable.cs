using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ORGANIZERNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    STARTDATEUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENDDATEUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TARGETTREECOUNT = table.Column<int>(type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
