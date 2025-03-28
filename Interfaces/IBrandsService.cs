using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;

namespace CarRentalApplication.Interfaces
{
    public interface IBrandsService
    {
        Task<ServiceResponse<int>> CreateBrand(string brandName);

        Task<ServiceResponse<bool>> DeleteBrand(int id);

        Task<ServiceResponse<Brand>> GetBrandById(int id);

        Task<ServiceResponse<bool>> EditBrandName(int id, string newName);
        Task<ServiceResponse<List<Brand>>> GetAllBrands();

        Task<ServiceResponse<bool>> AddModel(int brandId, string modelName);

        Task<ServiceResponse<bool>> DeleteModel(int modelId);

        Task<ServiceResponse<Model>> GetModelById(int modelId);

        Task<ServiceResponse<bool>> EditModelName(int modelId, string newName);

    }
}
