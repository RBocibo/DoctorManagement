using AutoMapper;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;

namespace DoctorManagement.Services.Services
{
    public class DoctorService : BaseService, IDoctorService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentRepository appointmentRepository)
            : base(unitOfWork, mapper)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<AppointmentDTO>> ListAppointmentAsync()
        {
            var listAppointments = await _appointmentRepository.GetAllAsync();

            var mapped =  _mapper.Map<IEnumerable<AppointmentDTO>>(listAppointments);
            return mapped;
        }
    }
}
