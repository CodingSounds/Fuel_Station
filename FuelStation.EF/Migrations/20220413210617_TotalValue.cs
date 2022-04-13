using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelStation.EF.Migrations
{
    public partial class TotalValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "TransactionLines",
                newName: "TotalValueOfLine");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TotalValueOfLine",
                table: "TransactionLines",
                newName: "TotalValue");
        }
    }
}
