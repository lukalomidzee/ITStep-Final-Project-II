using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.VMs.Cars
{
    public class CreateCarViewModel
    {
        // Car properties -----------------------------

        [Required]
        public int Brand { get; set; }

        [Required]
        public int Model { get; set; }

        [Required]
        [Range(1900, 2025)]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Engine { get; set; }

        [Required]
        public string Gearbox { get; set; }

        [Required]
        public string FuelCapacity { get; set; }

        [Required]
        [Range(2, 16)]
        public int Seats { get; set; }

        [Required]
        public string City { get; set; }

        public string? Latitude { get; set; } = default;

        public string? Longitude { get; set; } = default;

        // Price and Image
        [Required]
        public string Price { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();


    }
}