using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class FuelCapacitiesController : GenericSelectorController<FuelCapacities, float>
    {
        public FuelCapacitiesController(FuelCapacitiesService service) : base(service) { }

        protected override string ControllerName => "Fuel Capacities";
        protected override string DisplayName => "Fuel Capacity";
    }
}
