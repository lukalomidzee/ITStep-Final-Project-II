using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CarRentalApplication.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICarsService carsService, ApplicationDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICarsService _carsService = carsService;
        private readonly ApplicationDbContext _context = context;


        public async Task<IActionResult> Index()
        {
            var response = await _carsService.GetCarsListLimited(10);
            
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                List<int> likedCars = await _context.UsersCarsLikes.Where(ucl => ucl.UserId == userId).Select(ucl => ucl.CarId).ToListAsync();
                ViewBag.LikedCarsIds = likedCars;
            }
            return View(response.Data);
        }

        public IActionResult Introduction()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
