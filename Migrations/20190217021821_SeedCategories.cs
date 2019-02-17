using Microsoft.EntityFrameworkCore.Migrations;

namespace Stamps.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Definitive')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Commemorative')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Special')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Airmail')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Special Delivery')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('First Day Cover')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Occupation')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
