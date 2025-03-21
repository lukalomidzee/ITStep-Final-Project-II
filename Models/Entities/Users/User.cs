using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Roles;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Users
{
    public class User
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required int UserName { get; set; }

        [MinLength(9), MaxLength(9)]
        public required string PhoneNumber { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();

        public List<Car> PostedCar { get; set; } = new List<Car>();

        public List<Car> RentedCar { get; set; } = new List<Car>();

    }
}
