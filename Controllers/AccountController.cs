using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _context.Users
                .Include(u => u.PostedCar)
                .Include(u => u.Rentals).ThenInclude(c => c.Car)
                .Include(u => u.UsersCarsLikes).ThenInclude(ucl => ucl.Car)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
