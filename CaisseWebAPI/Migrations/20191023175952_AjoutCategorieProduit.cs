using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class AjoutCategorieProduit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieProduit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomCategorie = table.Column<string>(maxLength: 50, nullable: false),
                    DescriptionCategorie = table.Column<string>(maxLength: 250, nullable: false),
                    StatusCategorie = table.Column<sbyte>(type: "tinyint(1)", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProduit_NomCategorie",
                table: "CategorieProduit",
                column: "NomCategorie",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieProduit");
        }
    }
}
