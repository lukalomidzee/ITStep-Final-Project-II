using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class SeatsController : GenericSelectorController<Seats, int>
    {
        public SeatsController(SeatsService service) : base(service) { }

        protected override string ControllerName => "Seats";
        protected override string DisplayName => "Seats amount";
    }
}
