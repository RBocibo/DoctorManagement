using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;

        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
