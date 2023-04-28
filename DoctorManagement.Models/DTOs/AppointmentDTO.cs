using DoctorManagement.Domain.Entities.Enums;

namespace DoctorManagement.Models.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int PatientId { get; set; }
        public int OfficeId { get; set; }
    }
}
