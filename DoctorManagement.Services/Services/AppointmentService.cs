using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;

namespace DoctorManagement.Services.Services
{
    public class AppointmentService : BaseService, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentRepository appointmentRepository)
            : base(unitOfWork, mapper)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AddAppointmentDTO> AddAppointmentAsync(AddAppointmentDTO addAppointmentDTO)
        {
            var addAppointment = new Appointment()
            {
                AppointmentStatus = Domain.Entities.Enums.AppointmentStatus.Active,
                StartTime = addAppointmentDTO.StartTime,
                OfficeId = addAppointmentDTO.OfficeId,
                PatientId = addAppointmentDTO.PatientId,
            };

            await _appointmentRepository.CreateAsync(addAppointment);
            await _unitOfWork.CommitAsync();

            var mapped = _mapper.Map<AddAppointmentDTO>(addAppointment);
            return mapped;
        }

        public async Task<AppointmentDTO> GetAppointmentByIdAsync(int appointmentId)
        {
            var getAppointment = await _appointmentRepository.GetByIsAsync(x => x.AppointmentId == appointmentId);

            if(getAppointment == null)
            {
                return null;
            }

            var mappedAppointment = _mapper.Map<AppointmentDTO>(getAppointment);
            return mappedAppointment;
        }

        public async Task<IEnumerable<AppointmentDTO>> ListAppointmentAsync()
        {
            var listAppointments = await _appointmentRepository.GetAllAsync();

            var mapped =  _mapper.Map<IEnumerable<AppointmentDTO>>(listAppointments);
            return mapped;
        }

    }
}
