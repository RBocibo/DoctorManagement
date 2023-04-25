using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Domain.Entities
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public bool IsAnonymous { get; set; }
        public int WaitingTime { get; set; }
        public int Treatment { get; set; }
        public int Overall { get; set; }
        public string Comment { get; set; } = null!;
        public bool RecommendDoctor { get; set; }
        public DateTime ReviewDate { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
