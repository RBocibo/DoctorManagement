using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Commands.UpdatePatientCommands
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientDTO>
    {
        private readonly IPatientService _patientService;

        public UpdatePatientCommandHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<UpdatePatientDTO> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var response = await _patientService.UpdatePatientAsync(request.PatientId, request.Model);
            return response;
        }
    }
}
