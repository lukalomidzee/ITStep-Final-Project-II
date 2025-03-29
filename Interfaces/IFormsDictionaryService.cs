using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;

namespace CarRentalApplication.Interfaces
{
    public interface IFormsDictionaryService
    {
        #region Cities

        Task<ServiceResponse<List<Cities>>> GetAllCities();

        Task<ServiceResponse<int>> CreateCity(string cityName);
        
        Task<ServiceResponse<Cities>> GetCityById(int cityId);

        Task<ServiceResponse<bool>> UpdateCity(int cityId, string newName);

        Task<ServiceResponse<bool>> DeleteCity(int cityId);

        #endregion

        #region Colors

        Task<ServiceResponse<List<Colors>>> GetAllColors();

        Task<ServiceResponse<int>> CreateColor(string colorName);

        Task<ServiceResponse<Colors>> GetColorById(int colorId);

        Task<ServiceResponse<bool>> UpdateColor(int colorId, string newName);

        Task<ServiceResponse<bool>> DeleteColor(int colorId);

        #endregion

        #region Engines

        Task<ServiceResponse<List<Engines>>> GetAllEngines();

        Task<ServiceResponse<Engines>> CreateEngine(string engineName);

        Task<ServiceResponse<Engines>> GetEngineById(int engineId);

        Task<ServiceResponse<Engines>> UpdateEngine(int cityId, string newName);

        Task<ServiceResponse<Engines>> DeleteEngine(int cityId);

        #endregion
    }
}
