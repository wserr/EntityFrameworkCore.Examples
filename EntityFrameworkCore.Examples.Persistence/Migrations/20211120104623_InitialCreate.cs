using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Examples.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "FirstName", "LastName" },
                values: new object[] { 1, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "FirstName", "LastName" },
                values: new object[] { 2, "Allan", "Seth" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
