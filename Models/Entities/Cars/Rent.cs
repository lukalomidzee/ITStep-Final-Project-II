using CarRentalApplication.Models.Entities.Users;

namespace CarRentalApplication.Models.Entities.Cars
{
    public class Rent
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TotalDays { get; set; }

        public int Active { get; set; } = 1;

        public Car Car { get; set; }

        public User User { get; set; }
    }
}
