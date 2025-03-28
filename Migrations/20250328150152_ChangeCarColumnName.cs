using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Cars",
                newName: "Seats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Cars",
                newName: "Capacity");
        }
    }
}
