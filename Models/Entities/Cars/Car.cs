using CarRentalApplication.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Cars
{
    public class Car
    {
        public int Id { get; set; }

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
        public required int Seats { get; set; }

        public required string City { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        // Price and Image
        public required decimal Price { get; set; }

        public ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();

        public string? ImagePath { get; set; }

        // User properties ----------------------------
        public required string CreatorUserId { get; set; }

        public int LikeCount { get; set; }

        public int RentCount { get; set; }

        public int Status { get; set; } = 1;
        public User CreatorUser { get; set; }

        [MinLength(9), MaxLength(9)]
        public required string CreatorPhoneNummber { get; set; }

        public List<User> UserWhoRented { get; set; } = new List<User>();

        //public List<User> UsersWhoLiked { get; set; } = new List<User>();

        public List<UsersCarsLikes> UsersCarsLikes { get; set; } = new List<UsersCarsLikes>();

    }
}
