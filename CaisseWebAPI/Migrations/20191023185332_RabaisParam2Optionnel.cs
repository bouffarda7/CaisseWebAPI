using Microsoft.EntityFrameworkCore.Migrations;

namespace CaisseWebAPI.Migrations
{
    public partial class RabaisParam2Optionnel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Param2",
                table: "Rabais",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Param2",
                table: "Rabais",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);
        }
    }
}
