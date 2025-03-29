using CarRentalApplication.Models;

namespace CarRentalApplication.Interfaces
{
    public interface IGenericSelectorService<T> where T : class
    {
        Task<ServiceResponse<List<T>>> GetAllAsync();
        Task<ServiceResponse<T>> GetByIdAsync(int id);
        Task<ServiceResponse<int>> CreateAsync(string name);
        Task<ServiceResponse<bool>> UpdateAsync(int id, string newName);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
