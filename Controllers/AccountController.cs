using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarsService _carsService;

        public AccountController(ApplicationDbContext context, ICarsService carsService)
        {
            _context = context;
            _carsService = carsService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
