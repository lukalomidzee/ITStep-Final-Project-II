using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class VehicleFinder : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
