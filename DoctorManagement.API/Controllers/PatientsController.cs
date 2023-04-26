using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
using DoctorManagement.Core.CQRS.Commands.UpdatePatientCommands;
using DoctorManagement.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseController
    {
        public PatientsController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPatient([FromBody] PatientDTO patientDTO)
        {
            var command = new AddPatientCommand(patientDTO);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{patientId}")]
        public async Task<ActionResult> UpdatePatient(int patientId, UpdatePatientDTO patientDTO)
        {
            var command = new UpdatePatientCommand(patientId, patientDTO);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
