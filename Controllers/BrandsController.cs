using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandsService _brandsService;

        public BrandsController(ApplicationDbContext context, IBrandsService brandsService)
        {
            _context = context;
            _brandsService = brandsService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandsService.GetAllBrands();
            ViewBag.Brands = brands.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
            {
                TempData["Error"] = "Brand name cannot be empty";
                return RedirectToAction("Index");
            }

            var response = await _brandsService.CreateBrand(brandName);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _brandsService.DeleteBrand(id);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Brands/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandsService.GetBrandById(id);

            if (brand.Data == null)
            {
                TempData["Error"] = brand.Message;
                return RedirectToAction("Index");
            }

            ViewBag.Brand = brand.Data;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                TempData["Error"] = "Brand name cannot be empty";
                return RedirectToAction("Edit", new { id });
            }

            var response = await _brandsService.EditBrandName(id, newName);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpPost("Brands/Edit/{brandId}")]
        public async Task<IActionResult> AddModel(int brandId, string modelName)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                TempData["Error"] = "Model name cannot be empty";
                return RedirectToAction("Edit", new { brandId });
            }

            var response = await _brandsService.AddModel(brandId, modelName);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
            }

            return RedirectToAction("Edit", new { brandId });
        }
    }
}
