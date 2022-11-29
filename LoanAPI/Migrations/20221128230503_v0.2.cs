using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPI.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
