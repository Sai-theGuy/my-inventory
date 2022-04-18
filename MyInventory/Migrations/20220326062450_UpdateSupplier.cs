using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeLine.Migrations
{
    public partial class UpdateSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Representative",
                table: "Suppliers",
                newName: "ContactPerson");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "ContactPerson",
                table: "Suppliers",
                newName: "Representative");
        }
    }
}
