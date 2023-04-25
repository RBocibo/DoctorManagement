using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.AddPatientCommands
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, PatientDTO>
    {
        private readonly IPatientService _patientService;

        public AddPatientCommandHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public Task<PatientDTO> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var query = _patientService.AddPatient(request.Model);
            return query;
        }
    }
}
