using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDonations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DONORID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAMPAIGNID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    PAYMENTREFERENCE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    REMARKS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    VERIFIEDDATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Donations_Campaigns_CAMPAIGNID",
                        column: x => x.CAMPAIGNID,
                        principalTable: "Campaigns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donations_Donors_DONORID",
                        column: x => x.DONORID,
                        principalTable: "Donors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CAMPAIGNID",
                table: "Donations",
                column: "CAMPAIGNID");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DONORID",
                table: "Donations",
                column: "DONORID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
