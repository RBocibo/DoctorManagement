using DoctorManagement.Models.DTOs;

namespace DoctorManagement.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> ListAppointmentAsync();
        Task<AddAppointmentDTO> AddAppointmentAsync(AddAppointmentDTO addAppointmentDTO);
        Task<AppointmentDTO> GetAppointmentByIdAsync(int appointmentId);
        Task<IEnumerable<AppointmentDTO>> ListActiveAppointmentsAsync(int status);
    }
}
