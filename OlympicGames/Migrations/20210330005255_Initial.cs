using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(nullable: false),
                    GName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<string>(nullable: false),
                    SportName = table.Column<string>(nullable: true),
                    SportType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SportID = table.Column<string>(nullable: true),
                    GameID = table.Column<string>(nullable: true),
                    CountryImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GName" },
                values: new object[,]
                {
                    { "win", "Winter Olympics" },
                    { "sum", "Summer Olympics" },
                    { "par", "Paralympics" },
                    { "you", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "SportName", "SportType" },
                values: new object[,]
                {
                    { "cin", "Curling", "Indoor" },
                    { "bou", "Bobsleigh", "Outdoor" },
                    { "din", "Diving", "Indoor" },
                    { "rou", "Road Cycling", "Outdoor" },
                    { "ain", "Archery", "Indoor" },
                    { "cou", "Canoe Sprint", "Outdoor" },
                    { "bin", "Breakdancing", "Indoor" },
                    { "sou", "Skateboarding", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryImage", "GameID", "Name", "SportID" },
                values: new object[,]
                {
                    { "can", "Canada.PNG", "win", "Canada", "cin" },
                    { "rus", "Russia.PNG", "you", "Russia", "bin" },
                    { "fra", "France.PNG", "you", "France", "bin" },
                    { "cyp", "Cyprus.PNG", "you", "Cyprus", "bin" },
                    { "zim", "Zimbabwe.PNG", "par", "Zimbabwe", "cou" },
                    { "pak", "Pakistan.PNG", "par", "Pakistan", "cou" },
                    { "fin", "Finland.PNG", "par", "Finland", "cou" },
                    { "aus", "Austria.PNG", "par", "Austria", "cou" },
                    { "ura", "Uraguay.PNG", "par", "Uraguay", "ain" },
                    { "ukr", "Ukraine.PNG", "par", "Ukraine", "ain" },
                    { "tha", "Thailand.PNG", "par", "Thailand", "ain" },
                    { "usa", "USA.PNG", "sum", "USA", "rou" },
                    { "net", "Netherlands.PNG", "sum", "Netherlands", "rou" },
                    { "bra", "Brazil.PNG", "sum", "Brazil", "rou" },
                    { "mex", "Mexico.PNG", "sum", "Mexico", "din" },
                    { "ger", "Germany.PNG", "sum", "Germany", "din" },
                    { "chi", "China.PNG", "sum", "China", "din" },
                    { "jap", "Japan.PNG", "win", "Japan", "bou" },
                    { "jam", "Jamaica.PNG", "win", "Jamaica", "bou" },
                    { "ita", "Italy.PNG", "win", "Italy", "bou" },
                    { "swe", "Sweden.PNG", "win", "Sweden", "cin" },
                    { "gre", "GreatBritain.PNG", "win", "GreatBritain", "cin" },
                    { "por", "Portugal.PNG", "you", "Portugal", "sou" },
                    { "slo", "Slovakia.PNG", "you", "Slovakia", "sou" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportID",
                table: "Countries",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
