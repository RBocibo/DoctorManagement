using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.AddPatientCommands
{
    public class AddPatientCommand : IRequest<PatientDTO>
    {
        public PatientDTO Model { get; set; }

        public AddPatientCommand(PatientDTO model)
        {
            Model = model;
        }
    }
}
