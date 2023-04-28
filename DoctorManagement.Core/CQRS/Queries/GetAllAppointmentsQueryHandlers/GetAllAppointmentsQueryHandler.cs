using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;
using MediatR;

namespace DoctorManagement.Core.CQRS.Queries.GetAllAppointmentsQueryHandlers
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentDTO>>
    {
        private readonly IDoctorService _doctorService;

        public GetAllAppointmentsQueryHandler(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IEnumerable<AppointmentDTO>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var response = await _doctorService.ListAppointmentAsync();
            return response;
        }
    }
}
