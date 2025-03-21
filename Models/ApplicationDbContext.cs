using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Roles;
using CarRentalApplication.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CreatorUser)
                .WithMany(u => u.PostedCar)
                .HasForeignKey(c => c.CreatorUserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.UserWhoRented)
                .WithMany(u => u.RentedCar)
                .UsingEntity(j => j.ToTable("CarRentals"));
        }
    }
}
