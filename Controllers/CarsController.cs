using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApplication.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarsService _carsService;
        private readonly ISelectorsService _selectorsService;

        public CarsController(ICarsService carsService, ISelectorsService selectorsService, ApplicationDbContext context)
        {
            _carsService = carsService;
            _selectorsService = selectorsService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            var selectorData = await _selectorsService.GetAllSelectors();
            var brands = await _carsService.GetBrands();
            var selectors = new
            {
                Cities = selectorData[0],
                Colors = selectorData[1],
                Engines = selectorData[2],
                FuelCapacities = selectorData[3],
                Gearboxes = selectorData[4],
                Seats = selectorData[5],
                Years = selectorData[6]
            };
            ViewBag.Brands = brands.Data;
            ViewBag.Selectors = selectors;
            return View();
        }

        [HttpGet("/Cars/GetModelsByBrand/{brandId}")]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var models = await _carsService.GetModelsByBrand(brandId);

            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarPost([FromForm] CreateCarViewModel carModel, List<IFormFile> CarImages)
        {
            var modelState = ModelState;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Error"] = string.Join("; ", errors);
                return RedirectToAction("AddCar");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var phoneNumber = User.Identity.Name;

            if (phoneNumber == null)
            {
                TempData["Error"] = "Invalid car creation attempt - No phone number found";
                return RedirectToAction("AddCar");
            }

            var imagePaths = new List<string>();
            if (CarImages != null && CarImages.Count > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cars");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                foreach (var image in CarImages.Take(3))
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imagePaths.Add("/images/cars/" + fileName);
                }
            }

            var result = await _carsService.AddCar(userId, phoneNumber, carModel, imagePaths);

            if (result.Success)
            {
                TempData["Success"] = result.Message;
            }
            else
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("AddCar");

        }

        [HttpPost]
        public async Task<IActionResult> ToggleLike(int carId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Json(new { success = false, message = "User is not authenticated" });
            }

            var carExists = await _context.Cars.AnyAsync(c => c.Id == carId);
            if (!carExists)
            {
                return Json(new { success = false, message = "Car not found" });
            }

            var car = await _carsService.GetCarById(carId);

            var userLike = await _context.UsersCarsLikes
                .FirstOrDefaultAsync(ul => ul.UserId == userId && ul.CarId == carId);

            bool liked;

            if (userLike == null)
            {
                await _context.UsersCarsLikes.AddAsync(new UsersCarsLikes
                {
                    UserId = userId,
                    CarId = carId
                });
                liked = true;
                car.Data.LikeCount++;
            }
            else
            {
                _context.UsersCarsLikes.Remove(userLike);
                liked = false;
                car.Data.LikeCount--;
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, liked });
        }

        [HttpGet("/Cars/Details/{carId}")]
        public async Task<IActionResult> Details(int carId)
        {

            var result = await _carsService.GetCarById(carId);

            if (!result.Success)
            {
                TempData["Error"] = result.Message;
                return RedirectToAction("Index", "Home");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<int> likedCars = await _context.UsersCarsLikes.Where(ucl => ucl.UserId == userId).Select(ucl => ucl.CarId).ToListAsync();
            ViewBag.LikedCarsIds = likedCars;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int carId, int number)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                TempData["Error"] = "User is not authenticated";
                return RedirectToAction("Details", "Cars", new { id = carId });
            }

            var carExists = await _context.Cars.AnyAsync(c => c.Id == carId);
            if (!carExists)
            {
                TempData["Error"] = "Car doesn't exist";
                return RedirectToAction("Details", "Cars", new { id = carId });
            }

            var car = await _carsService.GetCarById(carId);

            if (car.Data.Status == 0)
            {
                TempData["Error"] = "Car not available";
                return RedirectToAction("Details", "Cars", new { id = carId });
            }

            var userRent = await _context.Rents
                .FirstOrDefaultAsync(r => r.UserId == userId && r.CarId == carId);

            if (userRent != null && userRent.Active != 0)
            {
                TempData["Error"] = "User already rented this car";
                return RedirectToAction("Details", "Cars", new { id = carId });
            }

            var carRent = await _context.Rents
                .FirstOrDefaultAsync(r => r.CarId == carId && DateTime.Now < r.EndDate);

            //if (carRent != null)
            //{
            //    TempData["Error"] = "Someone has already rented this car";
            //    return RedirectToAction("Details", "Cars", new { id = carId });
            //}

            await _context.Rents.AddAsync(new Rent
            {
                UserId = userId,
                CarId = carId,
                StartDate = DateTime.Now,
                TotalDays = number,
                EndDate = DateTime.Now.AddDays(number)
            });


            //car.Data.Status = 0;

            car.Data.RentCount++;
            await _context.SaveChangesAsync();
            TempData["Success"] = "Car rented successfully";
            return RedirectToAction("Index", "Home");
        }
    }
}
