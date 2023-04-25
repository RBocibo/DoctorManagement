using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Domain.Entities
{
    public class Doctor_Specialization
    {
        [Key]
        public int Doctor_SpecializationId { get; set; }

        [ForeignKey("SpecializationId")]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
