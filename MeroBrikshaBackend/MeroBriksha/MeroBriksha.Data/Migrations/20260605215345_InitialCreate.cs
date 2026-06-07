using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SCIENTIFICNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
