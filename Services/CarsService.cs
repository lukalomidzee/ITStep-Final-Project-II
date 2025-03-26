using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;

namespace CarRentalApplication.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext _context;

        public CarsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCar(string userId, string phoneNumber, CreateCarViewModel model)
        {
            Car car = new Car() {    
                Brand = model.Brand,
                Model = model.Model,
                Year = model.Year,
                Color = model.Color,
                Engine = model.Engine,
                Gearbox = model.Gearbox,
                FuelCapacity = model.FuelCapacity,
                Capacity = model.Capacity,
                City = model.City,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Price = model.Price,
                Image = model.Image,
                CreatorUserId = userId,
                CreatorPhoneNummber = phoneNumber
            };

            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
