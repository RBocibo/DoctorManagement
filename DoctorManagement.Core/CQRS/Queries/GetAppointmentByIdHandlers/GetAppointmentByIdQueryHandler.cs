using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAppointmentByIdHandlers
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public GetAppointmentByIdQueryHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AppointmentDTO> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.GetAppointmentByIdAsync(request.AppointmentId);
            return response;
        }
    }
}
