using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testDetails",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HotelCity = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    HotelDistrict = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    HotelDescription = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testDetails", x => x.HotelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testDetails");
        }
    }
}
