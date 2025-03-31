using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CarRentalApplication.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICarsService carsService, ApplicationDbContext context, UserManager<User> userManager) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICarsService _carsService = carsService;
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<User> _userManager;


        public async Task<IActionResult> Index()
        {
            var response = await _carsService.GetCarsListByPopularity(6);

            //var topThreeRent = response.Data.OrderBy(c => c.RentCount).Take(3).ToList();

            //var topThreeLike = response.Data.OrderBy(c => c.LikeCount).Take(3).ToList();

            //ViewBag.TopThreeRent = topThreeRent;
            //ViewBag.TopThreeLike = topThreeLike;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity.IsAuthenticated)
            {
                List<int> likedCars = await _context.UsersCarsLikes.Where(ucl => ucl.UserId == userId).Select(ucl => ucl.CarId).ToListAsync();
                ViewBag.LikedCarsIds = likedCars;
            }
            var roleClaims = User.FindAll(ClaimTypes.Role);

            return View(response.Data);
        }

        //public async Task<IActionResult> Index()
        //{
        //    var response = await _carsService.GetCarsListByPopularity(6);

        //    // Debugging if user is authenticated
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        Console.WriteLine("User is authenticated.");
        //        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        Console.WriteLine($"UserId: {userId}");

        //        List<int> likedCars = await _context.UsersCarsLikes
        //            .Where(ucl => ucl.UserId == userId)
        //            .Select(ucl => ucl.CarId)
        //            .ToListAsync();

        //        ViewBag.LikedCarsIds = likedCars;
        //    }
        //    else
        //    {
        //        Console.WriteLine("User is not authenticated.");
        //    }

        //    // Debugging roles and claims
        //    if (User.IsInRole("admin"))
        //    {
        //        Console.WriteLine("User is an Admin!");
        //    }
        //    else
        //    {
        //        var roleClaims = User.FindAll(ClaimTypes.Role);
        //        if (!roleClaims.Any())
        //        {
        //            Console.WriteLine("No role claims found for the user.");
        //        }
        //        else
        //        {
        //            foreach (var claim in roleClaims)
        //            {
        //                Console.WriteLine($"Role claim: {claim.Value}");
        //            }
        //        }

        //        Console.WriteLine("User is NOT an Admin!");
        //    }

        //    return View(response.Data);
        //}

        public async Task<IActionResult> Introduction()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/NotFound")]
        public async Task<IActionResult> NotFound()
        {
            return View();
        }
    }
}
