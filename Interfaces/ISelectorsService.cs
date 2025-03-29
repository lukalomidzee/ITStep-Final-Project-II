using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalApplication.Interfaces
{
    public interface ISelectorsService
    {
        Task<List<IEnumerable<SelectListItem>>> GetAllSelectors();
        Task<IEnumerable<SelectListItem>> GetCarCities();
        Task<IEnumerable<SelectListItem>> GetCarColors();
        Task<IEnumerable<SelectListItem>> GetCarEngines();
        Task<IEnumerable<SelectListItem>> GetCarFuelCapacities();
        Task<IEnumerable<SelectListItem>> GetCarGearboxes();
        Task<IEnumerable<SelectListItem>> GetCarSeats();
        Task<IEnumerable<SelectListItem>> GetCarYears();
    }
}
