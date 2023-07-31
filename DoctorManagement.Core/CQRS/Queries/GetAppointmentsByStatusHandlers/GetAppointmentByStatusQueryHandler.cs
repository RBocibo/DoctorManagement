using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAppointmentsByStatusHandlers
{
    public class GetAppointmentByStatusQueryHandler : IRequestHandler<GetAppointmentByStatusQuery, IEnumerable<AppointmentDTO>>
    {
        private readonly IAppointmentService _appointmentService;

        public GetAppointmentByStatusQueryHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IEnumerable<AppointmentDTO>> Handle(GetAppointmentByStatusQuery request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.ListActiveAppointmentsAsync(request.AppointmentStatus);
            return response;
        }
    }
}
