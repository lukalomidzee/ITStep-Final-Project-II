using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class ColorsController : GenericSelectorController<Colors, string>
    {
        public ColorsController(ColorsService service) : base(service) { }

        protected override string ControllerName => "Colors";
        protected override string DisplayName => "Colors";

        [HttpPost("EditColors/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditColors(int id, string model)
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
