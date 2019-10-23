using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class MaJStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "StatusProduit",
                table: "Produit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "EstAdmin",
                table: "Employe",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusCompte",
                table: "Compte",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusCategorie",
                table: "CategorieProduit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)",
                oldDefaultValueSql: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "StatusProduit",
                table: "Produit",
                type: "tinyint(1)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<sbyte>(
                name: "EstAdmin",
                table: "Employe",
                type: "tinyint(1)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<sbyte>(
                name: "StatusCompte",
                table: "Compte",
                type: "tinyint(1)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<sbyte>(
                name: "StatusCategorie",
                table: "CategorieProduit",
                type: "tinyint(1)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");
        }
    }
}
