using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;

namespace DoctorManagement.Services.Services
{
    public class PatientService : BaseRepository, IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDTO> AddPatient(PatientDTO patientDTO)
        {
            var addPatient = new Patient()
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                PhoneNumber = patientDTO.PhoneNumber,
                Email = patientDTO.Email,
            };

            await _patientRepository.CreateAsync(addPatient);
            await _unitOfWork.CommitAsync();

            var mappedPatient = _mapper.Map<PatientDTO>(addPatient);
            return mappedPatient;
        }
    }
}
