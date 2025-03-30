using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Cars",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Cars",
                newName: "Image");
        }
    }
}
