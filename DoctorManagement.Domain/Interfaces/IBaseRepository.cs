using System.Linq.Expressions;

namespace DoctorManagement.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindByListAsync(Expression<Func<TEntity, bool>> expression);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIsAsync(Expression<Func<TEntity, bool>> expression);
    }
}
