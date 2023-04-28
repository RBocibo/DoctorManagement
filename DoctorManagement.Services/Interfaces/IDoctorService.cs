using DoctorManagement.Models.DTOs;

namespace DoctorManagement.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<AppointmentDTO>> ListAppointmentAsync();
    }
}
