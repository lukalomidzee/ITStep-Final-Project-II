using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Dictionary;
using System.ComponentModel.Design;

namespace CarRentalApplication.Services
{
    public class FormsDictionaryService : IFormsDictionaryService
    {
        public Task<ServiceResponse<int>> CreateCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> CreateColor(string colorName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Engines>> CreateEngine(string engineName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteCity(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteColor(int colorId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Engines>> DeleteEngine(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Cities>>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Colors>>> GetAllColors()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Engines>>> GetAllEngines()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Cities>> GetCityById(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Colors>> GetColorById(int colorId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Engines>> GetEngineById(int engineId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpdateCity(int cityId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpdateColor(int colorId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Engines>> UpdateEngine(int cityId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
