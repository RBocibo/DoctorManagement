using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Models.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
