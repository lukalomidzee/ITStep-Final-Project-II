using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Services.Selectors
{
    public class SeatsService : GenericSelectorService<Seats, int>
    {
        public SeatsService(ApplicationDbContext context) : base(context) { }
    }
}
