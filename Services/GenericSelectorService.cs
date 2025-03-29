using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Services
{
    public class GenericSelectorService<T> : IGenericSelectorService<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericSelectorService(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<ServiceResponse<List<T>>> GetAllAsync()
        {
            return new ServiceResponse<List<T>> { Data = await _dbSet.ToListAsync(), Success = true };
        }

        public async Task<ServiceResponse<T>> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity == null
                ? new ServiceResponse<T> { Success = false, Message = "Not found" }
                : new ServiceResponse<T> { Data = entity, Success = true };
        }

        public async Task<ServiceResponse<int>> CreateAsync(string name)
        {
            var entity = Activator.CreateInstance(typeof(T)) as dynamic;
            entity.Name = name;

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = entity.Id, Success = true };
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(int id, string newName)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };
            }

            //entity.Name = newName;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Success = true };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Success = true };
        }
    }
}
