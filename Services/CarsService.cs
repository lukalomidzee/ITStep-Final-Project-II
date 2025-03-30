using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        #region Car CRUD
        public async Task<ServiceResponse<bool>> AddCar(string userId, string phoneNumber, CreateCarViewModel model, List<string> imagePaths)
        {
            var brandName = await _context.Brands.FirstOrDefaultAsync(b => b.Id == model.Brand);
            var modelName = await _context.Models.FirstOrDefaultAsync(m => m.Id == model.Model);

            if (brandName == null || modelName == null)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Invalid brand or model selection." };
            }

            Car car = new Car() {    
                Brand = brandName.Name,
                Model = modelName.Name,
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
                //ImagePath = imagePaths,
                CreatorUserId = userId,
                CreatorPhoneNummber = phoneNumber,
                LikeCount = 0,
                Status = 1
            };

            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                if (imagePaths.Any())
                {
                    var carImages = imagePaths.Select(path => new CarImage
                    {
                        CarId = car.Id,  // Use the saved car's ID
                        ImagePath = path
                    }).ToList();

                    await _context.CarImages.AddRangeAsync(carImages);
                    await _context.SaveChangesAsync();
                }

                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Car added successfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Couldn't add car" };
            }
            
        }

        public async Task<ServiceResponse<bool>> DeleteCar(int carId)
        {
            Car car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == carId);

            if (car == null)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Car not found" };
            }

            try
            {
                car.Status = 0;
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Car deleted successfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Couldn't delete car" };
            }
        }
        #endregion

        #region Car list
        public async Task<ServiceResponse<List<Car>>> GetCarsList()
        {
            var cars = await _context.Cars.Where(c => c.Status == 1).ToListAsync();
            try
            {
                return new ServiceResponse<List<Car>> { Data = cars, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Car>> { Data = null, Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsListLimited(int carCount)
        {
            var cars = await _context.Cars.Where(c => c.Status == 1).Take(carCount).ToListAsync();
            try
            {
                return new ServiceResponse<List<Car>> { Data = cars, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Car>> { Data = null, Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsListByUser(string userId)
        {
            var cars = await _context.Cars.Where(c => c.Status == 1 && c.CreatorUserId == userId).ToListAsync();
            try
            {
                return new ServiceResponse<List<Car>> { Data = cars, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Car>> { Data = null, Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<List<Car>>> GetCarsListByPopularity(int carCount)
        {
            var cars = await _context.Cars.Where(c => c.Status == 1).OrderByDescending(c => c.LikeCount).Take(carCount).ToListAsync();
            try
            {
                return new ServiceResponse<List<Car>> { Data = cars, Success = true };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Car>> { Data = null, Success = false, Message = ex.Message };
            }
        }

        #endregion


        #region Models and Brands
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
        #endregion
    }
}
