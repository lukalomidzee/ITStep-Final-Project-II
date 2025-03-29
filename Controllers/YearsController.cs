using CarRentalApplication.Models.Entities.Dictionary;
using CarRentalApplication.Services.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public class YearsController : GenericSelectorController<Years, int>
    {
        public YearsController(YearsService service) : base(service) { }

        protected override string ControllerName => "Years";
        protected override string DisplayName => "Years list";
    }
}
