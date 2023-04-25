using DoctorManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagement.Infrastructure.Data
{
    public class DoctorManagementDbContext : DbContext
    {
        public DoctorManagementDbContext(DbContextOptions<DoctorManagementDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Doctor_Specialization> Doctor_Specializations { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
