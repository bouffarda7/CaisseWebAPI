using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class Compte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 75, nullable: false),
                    IdAdresse = table.Column<int>(nullable: false),
                    NomUtilisateur = table.Column<string>(maxLength: 15, nullable: false),
                    MotPasse = table.Column<string>(maxLength: 60, nullable: false),
                    DateInscription = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusCompte = table.Column<sbyte>(type: "tinyint(1)", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compte_Adresse_IdAdresse",
                        column: x => x.IdAdresse,
                        principalTable: "Adresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompteTelephone",
                columns: table => new
                {
                    IdCompte = table.Column<int>(nullable: false),
                    IdTelephone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteTelephone", x => new { x.IdCompte, x.IdTelephone });
                    table.ForeignKey(
                        name: "FK_CompteTelephone_Compte_IdCompte",
                        column: x => x.IdCompte,
                        principalTable: "Compte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompteTelephone_Telephone_IdTelephone",
                        column: x => x.IdTelephone,
                        principalTable: "Telephone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compte_IdAdresse",
                table: "Compte",
                column: "IdAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_CompteTelephone_IdTelephone",
                table: "CompteTelephone",
                column: "IdTelephone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompteTelephone");

            migrationBuilder.DropTable(
                name: "Compte");
        }
    }
}
