using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class dbMig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saloons_Movies_MovieId",
                table: "Saloons");

            migrationBuilder.DropIndex(
                name: "IX_Saloons_MovieId",
                table: "Saloons");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Saloons");

            migrationBuilder.CreateTable(
                name: "MovieSaloons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    SaloonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSaloons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSaloons_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSaloons_Saloons_SaloonId",
                        column: x => x.SaloonId,
                        principalTable: "Saloons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaloons_MovieId",
                table: "MovieSaloons",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaloons_SaloonId",
                table: "MovieSaloons",
                column: "SaloonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSaloons");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Saloons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saloons_MovieId",
                table: "Saloons",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saloons_Movies_MovieId",
                table: "Saloons",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
