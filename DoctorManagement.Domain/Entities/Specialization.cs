using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Domain.Entities
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; } = null!;

        public ICollection<Doctor_Specialization> Doctor_Specializations { get; set; }     
    }
}
