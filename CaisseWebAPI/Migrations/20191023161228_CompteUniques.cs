using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class CompteUniques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Compte_Email",
                table: "Compte",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compte_NomUtilisateur",
                table: "Compte",
                column: "NomUtilisateur",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Compte_Email",
                table: "Compte");

            migrationBuilder.DropIndex(
                name: "IX_Compte_NomUtilisateur",
                table: "Compte");
        }
    }
}
