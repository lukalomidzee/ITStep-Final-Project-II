using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class ColorsService : GenericSelectorService<Colors, string>
    {
        public ColorsService(ApplicationDbContext context) : base(context) { }
    }
}
