using DoctorManagement.Domain.Entities.Enums;

namespace DoctorManagement.Models.DTOs
{
    public class AddAppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int PatientId { get; set; }
        public int OfficeId { get; set; }
    }
}
