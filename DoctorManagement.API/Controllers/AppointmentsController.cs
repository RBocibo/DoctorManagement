using DoctorManagement.Core.CQRS.Commands.AddAppointmentCommandHandlers;
using DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers;
using DoctorManagement.Core.CQRS.Queries.GetAppointmentByIdHandlers;
using DoctorManagement.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppointments()
        {
            var query = new GetAllAppointmentsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddAppointment([FromBody] AddAppointmentDTO addAppointment)
        {
            var command = new AddAppointmentCommand(addAppointment);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult> GetAppointmentById(int appointmentId)
        {
            var query = new GetAppointmentByIdQuery(appointmentId);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
