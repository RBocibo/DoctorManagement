namespace DoctorManagement.Domain.UnitOfWorkInterface
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
