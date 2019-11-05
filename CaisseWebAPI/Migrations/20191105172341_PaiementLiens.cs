using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class PaiementLiens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacture = table.Column<int>(nullable: false),
                    IdMethode = table.Column<int>(nullable: false),
                    MontantPaiment = table.Column<decimal>(type: "decimal(15,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiement_Facture_IdFacture",
                        column: x => x.IdFacture,
                        principalTable: "Facture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paiement_MethodePaiement_IdMethode",
                        column: x => x.IdMethode,
                        principalTable: "MethodePaiement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_IdFacture",
                table: "Paiement",
                column: "IdFacture");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_IdMethode",
                table: "Paiement",
                column: "IdMethode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paiement");
        }
    }
}
