using DoctorManagement.Models.DTOs;

namespace DoctorManagement.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDTO> AddPatient(PatientDTO patientDTO);
    }
}
