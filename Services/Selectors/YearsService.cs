using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class YearsService : GenericSelectorService<Years, int>
    {
        public YearsService(ApplicationDbContext context) : base(context) { }
    }
}
