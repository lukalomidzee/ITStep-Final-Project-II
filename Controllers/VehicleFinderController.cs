using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApplication.Controllers
{
    public class VehicleFinderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarsService _carsService;
        private readonly ISelectorsService _selectorsService;

        private const int PageSize = 3;

        public VehicleFinderController(ApplicationDbContext context, ICarsService carsService, ISelectorsService selectorsService)
        {
            _selectorsService = selectorsService;
            _carsService = carsService;
            _context = context;
        }

        // Index Method (for initial page load)
        public async Task<IActionResult> Index(int? year, int? seats, string? cityName, int? pageNumber)
        {
            var result = await _carsService.GetCarsList();
            var selectors = await _selectorsService.GetAllSelectors();

            var selectorsFiltered = new
            {
                Cities = selectors[0],
                Seats = selectors[5],
                Years = selectors[6]
            };

            ViewBag.Selectors = selectorsFiltered;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity.IsAuthenticated)
            {
                List<int> likedCars = await _context.UsersCarsLikes.Where(ucl => ucl.UserId == userId).Select(ucl => ucl.CarId).ToListAsync();
                ViewBag.LikedCarsIds = likedCars;
            }

            var cars = result.Data;

            // Apply filtering if values are passed
            if (year.HasValue)
            {
                cars = cars.Where(c => c.Year == year).ToList();
            }

            if (seats.HasValue)
            {
                cars = cars.Where(c => c.Seats == seats).ToList();
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                cars = cars.Where(c => c.City == cityName).ToList();
            }

            // Pagination logic
            var paginatedCars = cars.Skip(((pageNumber ?? 1) - 1) * PageSize).Take(PageSize).ToList();

            int totalPages = (int)Math.Ceiling(cars.Count / (double)PageSize);
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber ?? 1;

            return View(paginatedCars);
        }

        // Filter Method (handle form submission)
        [HttpPost]
        public async Task<IActionResult> Filter(int? year, int? seats, string? cityName, int? pageNumber)
        {
            var result = await _carsService.GetCarsList();
            var selectors = await _selectorsService.GetAllSelectors();

            var selectorsFiltered = new
            {
                Cities = selectors[0],
                Seats = selectors[5],
                Years = selectors[6]
            };

            ViewBag.Selectors = selectorsFiltered;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity.IsAuthenticated)
            {
                List<int> likedCars = await _context.UsersCarsLikes.Where(ucl => ucl.UserId == userId).Select(ucl => ucl.CarId).ToListAsync();
                ViewBag.LikedCarsIds = likedCars;
            }

            var cars = result.Data;

            // Apply filtering if values are passed
            if (year.HasValue)
            {
                cars = cars.Where(c => c.Year == year).ToList();
            }

            if (seats.HasValue)
            {
                cars = cars.Where(c => c.Seats == seats).ToList();
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                cars = cars.Where(c => c.City == cityName).ToList();
            }

            // Pagination logic
            var paginatedCars = cars.Skip(((pageNumber ?? 1) - 1) * PageSize).Take(PageSize).ToList();

            int totalPages = (int)Math.Ceiling(cars.Count / (double)PageSize);
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = pageNumber ?? 1;

            return View("Index", paginatedCars);
        }
    }
}
