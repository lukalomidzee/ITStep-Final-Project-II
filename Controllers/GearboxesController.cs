using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class GearboxesController : GenericSelectorController<Gearboxes, string>
    {
        public GearboxesController(GearboxesService service) : base(service) { }

        protected override string ControllerName => "Gearboxes";
        protected override string DisplayName => "Gearboxes";

        [HttpPost("EditConfirmed/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, string model)
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
