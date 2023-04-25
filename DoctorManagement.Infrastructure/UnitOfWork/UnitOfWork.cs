using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Infrastructure.Data;

namespace DoctorManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoctorManagementDbContext _dbContext;
        public UnitOfWork(DoctorManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
