using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Users;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApplication.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;
        private readonly ISelectorsService _selectorsService;

        public CarsController(ICarsService carsService, ISelectorsService selectorsService)
        {
            _carsService = carsService;
            _selectorsService = selectorsService;
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
        public async Task<IActionResult> AddCarPost([FromForm] CreateCarViewModel carModel)
        {
            var modelState = ModelState;

            var form = await Request.ReadFormAsync();
            foreach (var key in form.Keys)
            {
                Console.WriteLine($"{key}: {form[key]}");
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized();
                }

                var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);

                if (phoneNumber == null)
                {
                    TempData["Error"] = "Invalid car creation attempt";
                    return RedirectToAction("AddCar");
                }

                await _carsService.AddCar(userId, phoneNumber, carModel);
                return RedirectToAction("Index");
            }
            

            //TempData["Error"] = "Invalid car creation attempt";
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            TempData["Error"] = string.Join("; ", errors);

            return RedirectToAction("AddCar");
        }
    }
}
