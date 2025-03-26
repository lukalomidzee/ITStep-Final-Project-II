using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
