using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDonorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FULLNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PHONENUMBER = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
