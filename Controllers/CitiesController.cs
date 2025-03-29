using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class CitiesController : GenericSelectorController<Cities, string>
    {
        public CitiesController(CitiesService service) : base(service) { }

        protected override string ControllerName => "Cities";
        protected override string DisplayName => "Cities";

        [HttpPost("EditCities/{id}")/*, ActionName("Edit")*/]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCities(int id, string model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateAsync(id, model);
                if (!response.Success)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            if (string.IsNullOrWhiteSpace(model))
                TempData["Error"] = "Value couldn't be empty";

            return RedirectToAction(nameof(Index));
        }
    }

}
