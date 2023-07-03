using Microsoft.EntityFrameworkCore.Migrations;

namespace HttpClientExternalApi.Migrations
{
    public partial class newbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<float>(type: "real", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
