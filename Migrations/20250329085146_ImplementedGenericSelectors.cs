using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class ImplementedGenericSelectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Years",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "NumberOfSeats",
                table: "Seats",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Gearbox",
                table: "Gearboxes",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "FuelCapacity",
                table: "FuelCapacities",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EngineCapacity",
                table: "Engines",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Colors",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Years",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Seats",
                newName: "NumberOfSeats");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Gearboxes",
                newName: "Gearbox");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "FuelCapacities",
                newName: "FuelCapacity");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Engines",
                newName: "EngineCapacity");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Colors",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Cities",
                newName: "Name");
        }
    }
}
