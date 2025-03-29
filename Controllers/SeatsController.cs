using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class SeatsController : GenericSelectorController<Seats, int>
    {
        public SeatsController(SeatsService service) : base(service) { }

        protected override string ControllerName => "Seats";
        protected override string DisplayName => "Seats";

        [HttpPost("EditSeats/{id}")]
        public async Task<IActionResult> EditSeats(int id, int model)
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
