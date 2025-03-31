using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [Authorize(Roles = "admin")]
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
                    if (!response.Success)
                    {
                        TempData["Error"] = response.Message;
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            if (model <= 0)
                TempData["Error"] = "Value couldn't be lower than 0.1";

            return RedirectToAction(nameof(Index));
        }
    }
}
