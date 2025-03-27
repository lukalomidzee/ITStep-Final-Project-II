using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Interfaces
{
    public interface ICarsService
    {
        Task<bool> AddCar(string userId, string phoneNumber, CreateCarViewModel model);

        Task<bool> DeleteCar(int carId);
    }
}
