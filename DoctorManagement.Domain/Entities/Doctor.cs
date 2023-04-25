using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Domain.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ProfessionalStatement { get; set; } = null!;
        public DateTime PracticingStartDate { get; set; }

        public ICollection<Doctor_Specialization> Doctor_Specializations { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Office> Office { get; set; }
    }
}
