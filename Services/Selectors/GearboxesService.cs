using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class GearboxesService : GenericSelectorService<Gearboxes, string>
    {
        public GearboxesService(ApplicationDbContext context) : base(context) { }
    }
}
