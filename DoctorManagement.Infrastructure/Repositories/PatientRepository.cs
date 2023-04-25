using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Infrastructure.Data;

namespace DoctorManagement.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(DoctorManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}