using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using CarRentalApplication.Models.Entities.Cars;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Services
{
    public class BrandsService : IBrandsService
    {
        private readonly ApplicationDbContext _context;

        public BrandsService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Brand
        public async Task<ServiceResponse<int>> CreateBrand(string brandName)
        {
            string name = brandName.Trim();

            Brand brand = new Brand()
            {
                Name = name,
            };

            var brandExists = await _context.Brands.FirstOrDefaultAsync(b => b.Name == name);

            if (brandExists != null)
            {
                return new ServiceResponse<int> { Success = false, Message = "Brand already exists" };
            }

            try
            {
                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();
                return new ServiceResponse<int> { Data = brand.Id, Success = true, Message = "Brand added succesfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int> { Success = false, Message = "Couldn't create brand" };
            }

        }

        public async Task<ServiceResponse<bool>> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Brand not found" };
            }

            try
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Brand deleted succesfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Couldn't delete brand" };
            }
        }

        public async Task<ServiceResponse<bool>> EditBrandName(int id, string newName)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Brand not found" };
            }

            brand.Name = newName;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Success = true, Message = "Brand name updated" };
        }

        public async Task<ServiceResponse<List<Brand>>> GetAllBrands()
        {
            List<Brand> brands = await _context.Brands.OrderBy(b => b.Name).ToListAsync();

            return new ServiceResponse<List<Brand>> { Data = brands, Success = true, Message = "Brands found" };
        }

        public async Task<ServiceResponse<Brand>> GetBrandById(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return new ServiceResponse<Brand> { Success = false, Message = "Brand not found" };
            }

            brand.Models = await _context.Models.Where(m => m.BrandId == id).ToListAsync();

            return new ServiceResponse<Brand> { Data = brand, Success = true, Message = "Brand found" };
        }

        #endregion


        #region Model

        //public async Task<ServiceResponse<List<Model>>> GetAllModels

        public async Task<ServiceResponse<bool>> AddModel(int brandId, string modelName)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var brand = await GetBrandById(brandId);

                if (brand.Data == null)
                {
                    response.Success = false;
                    response.Message = "Brand not found.";
                    return response;
                }

                if (brand.Data.Models.Any(m => m.Name == modelName))
                {
                    response.Success = false;
                    response.Message = "Model already exists.";
                    return response;
                }

                var newModel = new Model
                {
                    Name = modelName,
                    BrandId = brandId
                };

                await _context.Models.AddAsync(newModel);
                await _context.SaveChangesAsync();

                response.Data = true;
                response.Success = true;
                response.Message = "Model added successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteModel(int modelId)
        {
            var model = await _context.Models.FirstOrDefaultAsync(m => m.Id == modelId);

            if (model == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Model not found" };
            }

            try
            {
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Model deleted succesfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Couldn't delete model" };
            }
        }

        public async Task<ServiceResponse<bool>> EditModelName(int modelId, string newName)
        {
            var model = await _context.Models.FirstOrDefaultAsync(m => m.Id == modelId);

            if (model == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Model not found" };
            }

            model.Name = newName;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Success = true, Message = "Model name updated" };
        }

        public async Task<ServiceResponse<Model>> GetModelById(int modelId)
        {
            Model model = await _context.Models.FirstOrDefaultAsync(m => m.Id == modelId);

            if (model == null)
            {
                return new ServiceResponse<Model> { Success = false, Message = "Model not found" };
            }

            return new ServiceResponse<Model> { Data = model, Success = true, Message = "Model found" };
        }


        #endregion

    }
}
