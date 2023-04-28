using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.AddAppointmentCommandHandlers
{
    public class AddAppointmentCommand : IRequest<AddAppointmentDTO>
    {
        public AddAppointmentDTO Model { get; set; }

        public AddAppointmentCommand(AddAppointmentDTO model)
        {
            Model = model;
        }
    }
}
