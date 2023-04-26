using DoctorManagement.Models.DTOs;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.UpdatePatientCommands
{
    public class UpdatePatientCommand : IRequest<UpdatePatientDTO>
    {
        public int PatientId { get; set; }
        public UpdatePatientDTO Model { get; set; }

        public UpdatePatientCommand(int patientId, UpdatePatientDTO model)
        {
            PatientId = patientId;
            Model = model;
        }
    }
}
