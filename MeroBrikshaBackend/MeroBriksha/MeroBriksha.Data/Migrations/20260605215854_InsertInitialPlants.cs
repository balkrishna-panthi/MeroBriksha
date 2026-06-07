using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeroBriksha.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertInitialPlants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "ID", "NAME", "SCIENTIFICNAME", "DESCRIPTION" },
                values: new object[,]
                {
            {
                "1",
                "Peepal",
                "Ficus religiosa",
                "A sacred tree commonly found in Nepal and South Asia."
            },
            {
                "2",
                "Banyan",
                "Ficus benghalensis",
                "A large shade-giving tree known for its aerial roots."
            },
            {
                "3",
                "Neem",
                "Azadirachta indica",
                "A medicinal tree known for its antibacterial properties."
            },
            {
                "4",
                "Rhododendron",
                "Rhododendron arboreum",
                "The national flower of Nepal, commonly found in hilly regions."
            },
            {
                "5",
                "Mango",
                "Mangifera indica",
                "A fruit-bearing tree suitable for warmer regions."
            }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "ID",
                keyValues: new object[]
                {
            "1", "2", "3", "4", "5"
                });
        }
    }
}
