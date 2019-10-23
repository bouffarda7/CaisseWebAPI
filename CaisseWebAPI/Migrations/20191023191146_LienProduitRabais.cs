using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class LienProduitRabais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRabais",
                table: "Produit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produit_IdRabais",
                table: "Produit",
                column: "IdRabais");

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Rabais_IdRabais",
                table: "Produit",
                column: "IdRabais",
                principalTable: "Rabais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Rabais_IdRabais",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_IdRabais",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "IdRabais",
                table: "Produit");
        }
    }
}
