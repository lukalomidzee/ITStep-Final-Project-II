using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class CitiesService : GenericSelectorService<Cities, string>
    {
        public CitiesService(ApplicationDbContext context) : base(context) { }

    }
}
