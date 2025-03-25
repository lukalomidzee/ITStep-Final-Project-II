using CarRentalApplication.Models.Entities.Users;

namespace CarRentalApplication.Models.Entities.Roles
{
    public class Role
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
