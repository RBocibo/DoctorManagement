using DoctorManagement.Domain.Entities.Enums;
using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAppointmentsByStatusHandlers
{
    public class GetAppointmentByStatusQuery : IRequest<IEnumerable<AppointmentDTO>>
    {
        public int AppointmentStatus { get; set; }

        public GetAppointmentByStatusQuery(int appointmentStatus)
        {
            AppointmentStatus = appointmentStatus;
        }
    }
}
