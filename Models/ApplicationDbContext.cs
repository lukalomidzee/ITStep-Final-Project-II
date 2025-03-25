using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Roles;
using CarRentalApplication.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

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
