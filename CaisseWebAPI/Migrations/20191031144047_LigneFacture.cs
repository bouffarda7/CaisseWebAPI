using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class LigneFacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LigneFacture",
                columns: table => new
                {
                    IdFacture = table.Column<int>(nullable: false),
                    IdProduit = table.Column<int>(nullable: false),
                    Quantite = table.Column<int>(nullable: false),
                    PrixRegulier = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    PrixAvecRabais = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    PrixTotalLigne = table.Column<decimal>(type: "decimal(15,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFacture", x => new { x.IdFacture, x.IdProduit });
                    table.ForeignKey(
                        name: "FK_LigneFacture_Facture_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Facture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LigneFacture_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LigneFacture_IdProduit",
                table: "LigneFacture",
                column: "IdProduit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LigneFacture");
        }
    }
}
