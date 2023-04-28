using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Infrastructure.Data;

namespace DoctorManagement.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DoctorManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
