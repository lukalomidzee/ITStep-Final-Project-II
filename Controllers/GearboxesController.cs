using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class GearboxesController : GenericSelectorController<Gearboxes, string>
    {
        public GearboxesController(GearboxesService service) : base(service) { }

        protected override string ControllerName => "Gearboxes";
        protected override string DisplayName => "Gearboxes";

        [HttpPost("EditGearboxes/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGearboxes(int id, string model)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateAsync(id, model);
                if (!response.Success)
                {
                    if (!response.Success)
                    {
                        TempData["Error"] = response.Message;
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            if (string.IsNullOrWhiteSpace(model))
                TempData["Error"] = "Value couldn't be empty";

            return RedirectToAction(nameof(Index));
        }
    }
}
