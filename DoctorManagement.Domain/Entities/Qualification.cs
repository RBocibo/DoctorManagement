using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Domain.Entities
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }
        public string QualificationName { get; set; } = null!;
        public string UniversityName { get; set; } = null!;
        public DateTime CompletedYear { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
