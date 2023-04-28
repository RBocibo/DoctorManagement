using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Infrastructure.Repositories;
using DoctorManagement.Infrastructure.UnitOfWork;

namespace DoctorManagement.API.Extensions
{
    public static class RepositoryConfiguration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        }
    }
}
