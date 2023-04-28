using DoctorManagement.Models.DTOs;

namespace DoctorManagement.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> ListAppointmentAsync();
        Task<AddAppointmentDTO> AddAppointmentAsync(AddAppointmentDTO addAppointmentDTO);
    }
}
