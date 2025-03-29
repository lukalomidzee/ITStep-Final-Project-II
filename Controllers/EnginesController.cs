using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class EnginesController : GenericSelectorController<Engines, float>
    {
        public EnginesController(EnginesService service) : base(service) { }

        protected override string ControllerName => "Engines";
        protected override string DisplayName => "Engines";

        [HttpPost("EditEngines/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEngines(int id, float model)
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
            if (model <= 0)
                TempData["Error"] = "Value couldn't be lower than 0.1";

            return RedirectToAction(nameof(Index));
        }
    }
}
