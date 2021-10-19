using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculator.Infrastructure.Migrations
{
    public partial class updateStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isremoved",
                table: "operations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isremoved",
                table: "operations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
