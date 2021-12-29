using Microsoft.EntityFrameworkCore.Migrations;

namespace olbe.Migrations
{
    public partial class Deneee1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userNameSurname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "BankAccount",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userNameSurname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "BankAccount");
        }
    }
}
