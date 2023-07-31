using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DoctorManagement.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DoctorManagementDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var toBeDeleted = _dbSet.Where(expression);
            
            if(toBeDeleted == null)
            {
                return;
            }

            _dbSet.RemoveRange(toBeDeleted);
        }

        public async Task<List<TEntity>> FindByListAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _dbSet.Where(expression).ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIsAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updated = _dbSet.Update(entity);

            return await Task.FromResult(entity);
        }
    }
}
