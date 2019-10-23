using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class LienCategorieProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelProduitCategorie",
                columns: table => new
                {
                    IdProduit = table.Column<int>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelProduitCategorie", x => new { x.IdProduit, x.IdCategorie });
                    table.ForeignKey(
                        name: "FK_RelProduitCategorie_CategorieProduit_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "CategorieProduit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelProduitCategorie_Produit_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelProduitCategorie_IdCategorie",
                table: "RelProduitCategorie",
                column: "IdCategorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelProduitCategorie");
        }
    }
}
