using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class EnginesService : GenericSelectorService<Engines, float>
    {
        public EnginesService(ApplicationDbContext context) : base(context) { }
    }
}
