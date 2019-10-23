using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class AjoutProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeProduit = table.Column<string>(maxLength: 60, nullable: false),
                    NomProduit = table.Column<string>(maxLength: 50, nullable: false),
                    DescriptionProduit = table.Column<string>(maxLength: 250, nullable: false),
                    PrixProduit = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    QuantiteProduit = table.Column<int>(nullable: false),
                    StatusProduit = table.Column<sbyte>(type: "tinyint(1)", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_NomProduit",
                table: "Produit",
                column: "NomProduit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produit");
        }
    }
}
