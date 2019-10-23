using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class LienRabaisType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTypeRabais",
                table: "Rabais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rabais_IdTypeRabais",
                table: "Rabais",
                column: "IdTypeRabais");

            migrationBuilder.AddForeignKey(
                name: "FK_Rabais_TypeRabais_IdTypeRabais",
                table: "Rabais",
                column: "IdTypeRabais",
                principalTable: "TypeRabais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rabais_TypeRabais_IdTypeRabais",
                table: "Rabais");

            migrationBuilder.DropIndex(
                name: "IX_Rabais_IdTypeRabais",
                table: "Rabais");

            migrationBuilder.DropColumn(
                name: "IdTypeRabais",
                table: "Rabais");
        }
    }
}
