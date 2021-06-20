using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Heroes_HeroID",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroID",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "HeroID",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "GroupLocation",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "KingdomName",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "King",
                table: "Kingdoms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KingdomCapitol",
                table: "Kingdoms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "King",
                table: "Kingdoms");

            migrationBuilder.DropColumn(
                name: "KingdomCapitol",
                table: "Kingdoms");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeroID",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupLocation",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KingdomName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroID",
                table: "Heroes",
                column: "HeroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Heroes_HeroID",
                table: "Heroes",
                column: "HeroID",
                principalTable: "Heroes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
