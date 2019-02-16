using Microsoft.EntityFrameworkCore.Migrations;

namespace Stamps.Migrations
{
    // ToDo: Use a sql script for production
    // Also see: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Continents
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('Africa')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('Antarctica')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('Asia')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('Europe')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('North America')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('Oceania')");
            migrationBuilder.Sql("INSERT INTO Continents (Name) VALUES ('South America')");

            // Insert some countries
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Argentina', (SELECT Id FROM Continents WHERE Name= 'South America'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Australia', (SELECT Id FROM Continents WHERE Name= 'Oceania'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Belgium', (SELECT Id FROM Continents WHERE Name= 'Europe'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('China', (SELECT Id FROM Continents WHERE Name= 'Asia'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('France', (SELECT Id FROM Continents WHERE Name= 'Europe'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Germany', (SELECT Id FROM Continents WHERE Name= 'Europe'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Senegal', (SELECT Id FROM Continents WHERE Name= 'Africa'))");
            migrationBuilder.Sql("INSERT INTO Countries (Name, ContinentId) VALUES ('Unites States of America', (SELECT Id FROM Continents WHERE Name= 'North America'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Continents");
        }
    }
}
