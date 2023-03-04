using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemGlobalServicesTest.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numCode = table.Column<int>(type: "int", nullable: false),
                    charCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nominal = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<float>(type: "real", nullable: false),
                    previous = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
