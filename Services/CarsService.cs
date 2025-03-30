using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.EntityFrameworkCore;

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
                Seats = model.Seats,
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

        public async Task<bool> DeleteCar(int carId)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return false;
            }

            try
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ServiceResponse<List<Brand>>> GetBrands()
        {
            var brands = await _context.Brands.OrderBy(b => b.Name).ToListAsync();
            try
            {
                return new ServiceResponse<List<Brand>> { Data = brands, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Brand>> { Data = null, Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<Model>>> GetModelsByBrand(int brandId)
        {
            var models = await _context.Models.Where(m => m.BrandId == brandId).OrderBy(m => m.Name).ToListAsync();
            try
            {
                return new ServiceResponse<List<Model>> { Data = models, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Model>> { Data = null, Success = false, Message = ex.Message };
            }
        }
    }
}
