using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Domain.Entities
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Decimal ConsultationFee { get; set; }
        public Decimal FollowUpConsulationFee { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
