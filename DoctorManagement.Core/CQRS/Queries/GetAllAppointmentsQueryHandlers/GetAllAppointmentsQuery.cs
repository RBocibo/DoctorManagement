using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers
{
    public class GetAllAppointmentsQuery : IRequest<IEnumerable<AppointmentDTO>>
    {
    }
}
