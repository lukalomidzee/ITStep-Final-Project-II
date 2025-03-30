using CarRentalApplication.Models.Entities.Cars;

namespace CarRentalApplication.Models.Entities.Users
{
    public class UsersCarsLikes
    {
        public int Id { get; set; }
        public string UserId { get; set; }  
        public int CarId { get; set; }

        public User User { get; set; }      
        public Car Car { get; set; }
    }
}
