using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangesWithUserCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    RentedCarId = table.Column<int>(type: "int", nullable: false),
                    UserWhoRentedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => new { x.RentedCarId, x.UserWhoRentedId });
                    table.ForeignKey(
                        name: "FK_CarRentals_Cars_RentedCarId",
                        column: x => x.RentedCarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentals_Users_UserWhoRentedId",
                        column: x => x.UserWhoRentedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_UserWhoRentedId",
                table: "CarRentals",
                column: "UserWhoRentedId");
        }
    }
}
