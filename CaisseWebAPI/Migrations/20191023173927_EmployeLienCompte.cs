using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class EmployeLienCompte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompte",
                table: "Employe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employe_IdCompte",
                table: "Employe",
                column: "IdCompte");

            migrationBuilder.AddForeignKey(
                name: "FK_Employe_Compte_IdCompte",
                table: "Employe",
                column: "IdCompte",
                principalTable: "Compte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employe_Compte_IdCompte",
                table: "Employe");

            migrationBuilder.DropIndex(
                name: "IX_Employe_IdCompte",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "IdCompte",
                table: "Employe");
        }
    }
}
