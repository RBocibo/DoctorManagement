using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorManagement.Domain.Entities.Enums;

namespace DoctorManagement.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("OfficeId")]
        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
