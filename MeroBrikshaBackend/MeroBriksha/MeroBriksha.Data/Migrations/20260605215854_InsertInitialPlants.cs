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
                Guid.NewGuid().ToString(),
                "Peepal",
                "Ficus religiosa",
                "A sacred tree commonly found in Nepal and South Asia."
            },
            {
                Guid.NewGuid().ToString(),
                "Banyan",
                "Ficus benghalensis",
                "A large shade-giving tree known for its aerial roots."
            },
            {
                Guid.NewGuid().ToString(),
                "Neem",
                "Azadirachta indica",
                "A medicinal tree known for its antibacterial properties."
            },
            {
                Guid.NewGuid().ToString(),
                "Rhododendron",
                "Rhododendron arboreum",
                "The national flower of Nepal, commonly found in hilly regions."
            },
            {
                Guid.NewGuid().ToString(),
                "Mango",
                "Mangifera indica",
                "A fruit-bearing tree suitable for warmer regions."
            }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Plants");
        }
    }
}
