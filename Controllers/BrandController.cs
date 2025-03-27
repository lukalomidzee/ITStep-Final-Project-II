using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
