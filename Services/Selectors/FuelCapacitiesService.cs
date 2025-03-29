using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class FuelCapacitiesService : GenericSelectorService<FuelCapacities, float>
    {
        public FuelCapacitiesService(ApplicationDbContext context) : base(context) { }
    }
}
