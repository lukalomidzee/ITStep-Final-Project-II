using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class ColorsController : GenericSelectorController<Colors, string>
    {
        public ColorsController(ColorsService service) : base(service) { }

        protected override string ControllerName => "Colors";
        protected override string DisplayName => "Color";
    }

}
