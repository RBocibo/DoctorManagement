using AutoMapper;
using DoctorManagement.Domain.Entities;
using DoctorManagement.Domain.Interfaces;
using DoctorManagement.Domain.UnitOfWorkInterface;
using DoctorManagement.Models.DTOs;
using DoctorManagement.Services.Interfaces;

namespace DoctorManagement.Services.Services
{
    public class PatientService : BaseService, IPatientService
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

        public async Task<UpdatePatientDTO> UpdatePatientAsync(int patientId, UpdatePatientDTO patientDTO)
        {
            var patient = await _patientRepository.GetByIsAsync(x => x.PatientId == patientId);

            if (patient == null)
            {
                return null;
            }

            patient.FirstName = patientDTO.FirstName != null ? patientDTO.FirstName : patient.FirstName;
            patient.LastName = patientDTO.LastName != null ? patientDTO.LastName : patient.LastName;
            patient.PhoneNumber = patientDTO.PhoneNumber != null ? patientDTO.PhoneNumber : patient.PhoneNumber;
            patient.Email = patientDTO.Email != null ? patientDTO.Email : patient.Email;

            await _patientRepository.UpdateAsync(patient);

            var mapped = _mapper.Map<UpdatePatientDTO>(patient);
            return mapped;
        }
    }
}
