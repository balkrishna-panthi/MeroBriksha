using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations.postgre
{
    /// <inheritdoc />
    public partial class FirstPostgre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NAME = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ORGANIZERNAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    STARTDATEUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ENDDATEUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TARGETTREECOUNT = table.Column<int>(type: "integer", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ISDELETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FULLNAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PHONENUMBER = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ADDRESS = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NAME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SPECIES = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SCIENTIFICNAME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DONORID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CAMPAIGNID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AMOUNT = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    PAYMENTREFERENCE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    REMARKS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VERIFIEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TreeAssignments",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DONATIONID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    REMARKS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TreeAssignments_Donations_DONATIONID",
                        column: x => x.DONATIONID,
                        principalTable: "Donations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    ID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TREEASSIGNMENTID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PLANTID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LOCATIONLINK = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "numeric(10,7)", precision: 10, scale: 7, nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "numeric(10,7)", precision: 10, scale: 7, nullable: true),
                    PLANTEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    TRACKINGCODE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CREATEDDATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "IX_Donations_CAMPAIGNID",
                table: "Donations",
                column: "CAMPAIGNID");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DONORID",
                table: "Donations",
                column: "DONORID");

            migrationBuilder.CreateIndex(
                name: "IX_TreeAssignments_DONATIONID",
                table: "TreeAssignments",
                column: "DONATIONID");

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

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "TreeAssignments");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
