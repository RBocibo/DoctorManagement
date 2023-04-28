using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.AddAppointmentCommandHandlers
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, AddAppointmentDTO>
    {
        private readonly IAppointmentService _appointmentService;

        public AddAppointmentCommandHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AddAppointmentDTO> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.AddAppointmentAsync(request.Model);
            return response;
        }
    }
}
