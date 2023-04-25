using System.Reflection;

namespace DoctorManagement.API.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("DoctorManagement.Models"));
        }
    }
}
