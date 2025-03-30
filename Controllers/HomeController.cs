using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRentalApplication.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICarsService carsService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICarsService _carsService = carsService;

        public async Task<IActionResult> Index()
        {
            var response = await _carsService.GetCarsListLimited(10);
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
