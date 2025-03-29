using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Services
{
    public class GenericSelectorService<T, TValue> : IGenericSelectorService<T, TValue> where T : class, ISelector<TValue>, new()
        /*IGenericSelectorService<T> where T : class*/
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
            var entities = await _dbSet.ToListAsync();
            if (entities == null)
            {
                return new ServiceResponse<List<T>> { Success = false, Message = "Not found" };
            }
            return new ServiceResponse<List<T>> { Data = entities, Success = true };
        }

        public async Task<ServiceResponse<T>> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null
                ? new ServiceResponse<T> { Data = entity, Success = true }
                : new ServiceResponse<T> { Success = false, Message = "Not found" };
        }

        public async Task<ServiceResponse<int>> CreateAsync(TValue value)
        {
            var entity = new T { Value = value };

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = entity.Id, Success = true };
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(int id, TValue newValue)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };

            entity.Value = newValue;
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Success = true };
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true, Success = true };
        }
    }
}
