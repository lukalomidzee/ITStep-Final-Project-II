using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class GearboxesController : GenericSelectorController<Gearboxes, string>
    {
        public GearboxesController(GearboxesService service) : base(service) { }

        protected override string ControllerName => "Gearboxes";
        protected override string DisplayName => "Gearbox type";
    }
}
