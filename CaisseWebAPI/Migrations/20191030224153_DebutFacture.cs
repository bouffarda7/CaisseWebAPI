using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class DebutFacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmploye = table.Column<int>(nullable: false),
                    IdCompte = table.Column<int>(nullable: false),
                    DateFacture = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    SousTotal = table.Column<decimal>(type: "decimal(15,4)", nullable: false, defaultValue: 0m),
                    TotalTaxe = table.Column<decimal>(type: "decimal(15,4)", nullable: false, defaultValue: 0m),
                    TotalAvecTaxe = table.Column<decimal>(type: "decimal(15,4)", nullable: false, defaultValue: 0m),
                    IdRabais = table.Column<int>(nullable: true),
                    CommentaireFacture = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facture_Compte_IdCompte",
                        column: x => x.IdCompte,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facture_Employe_IdEmploye",
                        column: x => x.IdEmploye,
                        principalTable: "Employe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facture_Rabais_IdRabais",
                        column: x => x.IdRabais,
                        principalTable: "Rabais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_IdCompte",
                table: "Facture",
                column: "IdCompte");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_IdEmploye",
                table: "Facture",
                column: "IdEmploye");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_IdRabais",
                table: "Facture",
                column: "IdRabais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facture");
        }
    }
}
