using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using CarRentalApplication.Models.VMs.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Interfaces
{
    public interface ICarsService
    {
        Task<ServiceResponse<bool>> AddCar(string userId, string phoneNumber, CreateCarViewModel model, List<string> imagePaths);

        Task<ServiceResponse<bool>> DeleteCar(int carId);

        Task<ServiceResponse<List<Car>>> GetCarsList();

        Task<ServiceResponse<List<Car>>> GetCarsListLimited(int carCount);

        Task<ServiceResponse<List<Car>>> GetCarsListByUser(string userId);

        Task<ServiceResponse<List<Car>>> GetCarsListByPopularity(int carCount);

        Task<ServiceResponse<List<Brand>>> GetBrands();

        Task<ServiceResponse<List<Model>>> GetModelsByBrand(int brandId);
    }
}
