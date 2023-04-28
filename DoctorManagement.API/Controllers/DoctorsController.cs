using DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoctorManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
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
    }
}
