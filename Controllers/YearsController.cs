using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class YearsController : GenericSelectorController<Years, int>
    {
        public YearsController(YearsService service) : base(service) { }

        protected override string ControllerName => "Years";
        protected override string DisplayName => "Years";

        [HttpPost("EditYears/{id}")]
        public async Task<IActionResult> EditYears(int id, int model)
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
                TempData["Error"] = "Value couldn't be lower than 0";

            return RedirectToAction(nameof(Index));
        }
    }
}
