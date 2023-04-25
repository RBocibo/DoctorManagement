using DoctorManagement.Core.CQRS.Commands.AddPatientCommands;
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
    }
}
