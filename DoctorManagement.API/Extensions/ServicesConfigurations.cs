using DoctorManagement.Services.Interfaces;
using DoctorManagement.Services.Services;

namespace DoctorManagement.API.Extensions
{
    public static class ServicesConfigurations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
        }
    }
}
