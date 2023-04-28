using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAppointmentByIdHandlers
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentDTO>
    {
        public int AppointmentId { get; set; }

        public GetAppointmentByIdQuery(int appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
