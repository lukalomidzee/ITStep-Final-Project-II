using CarRentalApplication.Models.Entities.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalApplication.Models.VMs.Cars
{
    public class VehicleFinderViewModel
    {
        public int? SelectedYear { get; set; }
        public int? SelectedSeats { get; set; }
        public string? SelectedCity { get; set; }

        // Dropdown options
        public SelectList YearOptions { get; set; }
        public SelectList SeatsOptions { get; set; }
        public SelectList CityOptions { get; set; }

        // Results
        public PaginatedList<Car> Vehicles { get; set; }
    }
}

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        this.AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}
