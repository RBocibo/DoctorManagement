using DoctorManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagement.API.Extensions
{
    public static class DatabaseConfigurations
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoctorManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DoctorManagementConnStr"));
            });
        }
    }
}
