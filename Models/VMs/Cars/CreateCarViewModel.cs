using CarRentalApplication.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.VMs.Cars
{
    public class CreateCarViewModel
    {
            // Car properties -----------------------------
        public required string Brand { get; set; }

        public required string Model { get; set; }

        [Range(1900, 2025)]
        public required int Year { get; set; }

        public required string Color { get; set; }

        public required string Engine { get; set; }

        public required string Gearbox { get; set; }

        public required string FuelCapacity { get; set; }

        [Range(2, 7)]
        public required int Capacity { get; set; }

        public required string City { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        // Price and Image
        public required string Price { get; set; }

        public required string Image { get; set; }

    }
}