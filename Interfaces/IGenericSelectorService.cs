using CarRentalApplication.Models;

namespace CarRentalApplication.Interfaces
{
    public interface IGenericSelectorService<T, TValue> where T : class, ISelector<TValue>, new()
    {
        Task<ServiceResponse<List<T>>> GetAllAsync();
        Task<ServiceResponse<T>> GetByIdAsync(int id);
        Task<ServiceResponse<int>> CreateAsync(TValue value);
        Task<ServiceResponse<bool>> UpdateAsync(int id, TValue newValue);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
