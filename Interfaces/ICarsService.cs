using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Interfaces
{
    public interface ICarsService
    {
        Task<ServiceResponse<bool>> AddCar(string userId, string phoneNumber, CreateCarViewModel model);

        Task<bool> DeleteCar(int carId);

        Task<ServiceResponse<List<Brand>>> GetBrands();

        Task<ServiceResponse<List<Model>>> GetModelsByBrand(int brandId);
    }
}
