using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class YearsController : GenericSelectorController<Years, int>
    {
        public YearsController(YearsService service) : base(service) { }

        protected override string ControllerName => "Years";
        protected override string DisplayName => "Years";

        [HttpPost("EditConfirmed/{id}")]
        public async Task<IActionResult> EditConfirmed(int id, int model)
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
                TempData["Error"] = "Value couldn't be lower than 0";

            return RedirectToAction(nameof(Index));
        }
    }
}
