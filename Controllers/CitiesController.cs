using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class CitiesController : GenericSelectorController<Cities, string>
    {
        public CitiesController(CitiesService service) : base(service) { }

        protected override string ControllerName => "Cities";
        protected override string DisplayName => "City";
    }

}
