using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Roles;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Users
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public List<Car> PostedCar { get; set; } = new List<Car>();

        //public List<Car> RentedCar { get; set; } = new List<Car>();

        public List<Rent> Rentals { get; set; } = new List<Rent>();

        //public List<Car> LikedCar { get; set; } = new List<Car>();

        public List<UsersCarsLikes> UsersCarsLikes { get; set; } = new List<UsersCarsLikes>();


    }
}
