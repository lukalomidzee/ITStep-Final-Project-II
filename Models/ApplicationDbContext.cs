using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Models.Entities.Roles;
using CarRentalApplication.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }  

        public DbSet<Cities> Cities { get; set; }
        
        public DbSet<Colors> Colors { get; set; }

        public DbSet<Engines> Engines { get; set; }

        public DbSet<FuelCapacities> FuelCapacities { get; set; }

        public DbSet<Gearboxes> Gearboxes { get; set; }

        public DbSet<Seats> Seats { get; set; }

        public DbSet<Years> Years { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Car>()
                .HasOne(c => c.CreatorUser)
                .WithMany(u => u.PostedCar)
                .HasForeignKey(c => c.CreatorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.UserWhoRented)
                .WithMany(u => u.RentedCar)
                .UsingEntity(j => j.ToTable("CarRentals"));

            modelBuilder.Entity<Brand>().HasMany(b => b.Models)
                .WithOne(m => m.Brand)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
