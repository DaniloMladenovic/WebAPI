using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupSize = table.Column<int>(type: "int", nullable: false),
                    GroupType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KingdomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KingdomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_Kingdoms_KingdomID",
                        column: x => x.KingdomID,
                        principalTable: "Kingdoms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroOrder = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    HeroID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Heroes_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Heroes_Heroes_HeroID",
                        column: x => x.HeroID,
                        principalTable: "Heroes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_KingdomID",
                table: "Groups",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_GroupID",
                table: "Heroes",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroID",
                table: "Heroes",
                column: "HeroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
