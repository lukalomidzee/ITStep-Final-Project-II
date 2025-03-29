using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class EnginesController : GenericSelectorController<Engines, float>
    {
        public EnginesController(EnginesService service) : base(service) { }

        protected override string ControllerName => "Engines";
        protected override string DisplayName => "Engine Size";
    }
}
